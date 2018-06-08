using Microsoft.AspNetCore.Mvc;
using OtakuNET.Domain.DataProviders;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly IDbContext dbContext;
        public ImageController(IDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<IActionResult> Get(int id)
        {
            var image = await dbContext.Images.FindAsync(id);
            if (image == null)
                return NotFound();

            return File(image.Data, image.MimeType);
        }
    }
}