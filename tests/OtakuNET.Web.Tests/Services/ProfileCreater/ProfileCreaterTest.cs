using OtakuNET.Web.Services.ProfileCreater;
using Xunit;

namespace OtakuNET.Web.Tests.Services
{
    public class ProfileCreaterTest
    {
        [Fact]
        public void Create()
        {
            var id = "qwe";
            var login = "testLogin";

            var result = new ProfileCreater().Create(id, login);

            Assert.Equal(id, result.Id);
            Assert.Equal(login, result.Login);
            Assert.Equal(6, result.AnimeListSet.Count);
            Assert.Equal(6, result.MangaListSet.Count);
            Assert.Single(result.History);
        }
    }
}
