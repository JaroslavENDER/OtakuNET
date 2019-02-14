using OtakuNET.Domain.Enums;
using OtakuNET.Web.Services.ProfileCreater;
using System.Linq;
using Xunit;

namespace OtakuNET.Web.Tests.Services
{
    public class ProfileCreaterTest
    {
        [Fact]
        public void Create()
        {
            var applicationUserId = "qwe";
            var login = "testLogin";

            var result = new ProfileCreater().Create(applicationUserId, login);

            Assert.Equal(applicationUserId, result.ApplicationUserId);
            Assert.Equal(login, result.Login);
            Assert.Equal(6, result.UserLists.Count(ul => ul.Type == TitleType.Anime));
            Assert.Equal(6, result.UserLists.Count(ul => ul.Type == TitleType.Manga));
            Assert.Single(result.History);
        }
    }
}
