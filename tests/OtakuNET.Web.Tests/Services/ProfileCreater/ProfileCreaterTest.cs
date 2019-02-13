using OtakuNET.Web.Services.ProfileCreater;
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
            Assert.Equal(6, result.AnimeList.Count);
            Assert.Equal(6, result.MangaList.Count);
            Assert.Single(result.History);
        }
    }
}
