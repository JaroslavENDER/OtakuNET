using OtakuNET.Web.Services.TagTranslator.Frontend;
using System;
using Xunit;

namespace OtakuNET.Web.Tests.Services
{
    public class TagTranslatorToEpisodeStringTest
    {
        private IFrontendTagTranslator translator = new FrontendTagTranslator();

        [Fact]
        public void NumberToEpisodeString()
        {
            Assert.Equal("9 эпизод", translator.ToEpisodeString("9"));
        }

        [Fact]
        public void StringToEpisodeString()
        {
            Assert.Throws<InvalidOperationException>(() => translator.ToEpisodeString("jjj"));
        }
    }
}
