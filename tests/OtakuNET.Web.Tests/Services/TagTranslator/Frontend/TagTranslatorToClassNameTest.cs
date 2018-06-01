using OtakuNET.Web.Models;
using OtakuNET.Web.Services.TagTranslator.Frontend;
using Xunit;

namespace OtakuNET.Web.Tests.Services
{
    public class TagTranslatorToClassNameTest
    {
        private IFrontendTagTranslator translator = new FrontendTagTranslator();

        [Fact]
        public void NewsToClassName()
        {
            Assert.Equal("tag--news", translator.ToClassName(Tag.News));
        }

        [Fact]
        public void AnnounceToClassName()
        {
            Assert.Equal("tag--announce", translator.ToClassName(Tag.Announce));
        }

        [Fact]
        public void OngoingToClassName()
        {
            Assert.Equal("tag--ongoing", translator.ToClassName(Tag.Ongoing));
        }

        [Fact]
        public void EpisodeToClassName()
        {
            Assert.Equal("tag--episode", translator.ToClassName(Tag.Episode));
        }

        [Fact]
        public void ReleaseToClassName()
        {
            Assert.Equal("tag--release", translator.ToClassName(Tag.Release));
        }
    }
}
