using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.AccountViewModels;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.ProfileCreater;
using System;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDbContext _dbContext;
        private readonly IEmailSender _emailSender;
        private readonly IProfileCreater _profileCreater;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IDbContext dbContext,
            IEmailSender emailSender,
            IProfileCreater profileCreater)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _emailSender = emailSender;
            _profileCreater = profileCreater;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
                return RedirectToLocal(returnUrl);
            if (result.IsLockedOut)
                return RedirectToAction(nameof(Lockout));

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
                throw new ApplicationException($"Unable to load two-factor authentication user.");

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
                throw new ApplicationException($"Unable to load two-factor authentication user.");

            var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);
            var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            if (result.Succeeded)
                return RedirectToLocal(returnUrl);
            if (result.IsLockedOut)
                return RedirectToAction(nameof(Lockout));

            ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser { UserName = model.Login, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                _dbContext.Profiles.Add(_profileCreater.Create(user.Id, model.Login));
                await _dbContext.SaveChangesAsync();

                await SendConfirmation(user, model.Email, Request.Scheme);

                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToLocal(returnUrl);
            }

            AddErrors(result);
            return View(model);
        }

        [AllowAnonymous]
        public async Task<JsonResult> LoginValidate(string login)
        {
            var profile = await _dbContext.Profiles.FirstOrDefaultAsync(p => p.Login.Equals(login, StringComparison.OrdinalIgnoreCase));
            if (profile == null)
                return Json(true);
            return Json($"User name '{login}' is already taken.");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");

            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
            await _emailSender.SendEmailAsync(model.Email, "Reset Password", $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code)
        {
            if (code == null)
                throw new ApplicationException("A code must be supplied for password reset.");

            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return RedirectToAction(nameof(ResetPasswordConfirmation));

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
                return RedirectToAction(nameof(ResetPasswordConfirmation));

            AddErrors(result);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task SendConfirmation(ApplicationUser user, string email, string requestScheme)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.EmailConfirmationLink(user.Id, code, requestScheme);
            await _emailSender.SendEmailConfirmationAsync(email, callbackUrl);
        }

        #endregion
    }
}
