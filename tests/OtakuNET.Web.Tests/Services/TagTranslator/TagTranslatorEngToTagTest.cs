using OtakuNET.Web.Models;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;
using System;
using Xunit;

namespace OtakuNET.Web.Tests.Services
{
    public class TagTranslatorEngToTagTest
    {
        private ITagTranslator translator = new TagTranslatorEng();

        [Fact]
        public void NewsToTag()
        {
            Assert.Equal(Tag.News, translator.ToTag("news"));
        }

        [Fact]
        public void AnnounseToTag()
        {
            Assert.Equal(Tag.Announce, translator.ToTag("announce"));
        }

        [Fact]
        public void OngoingToTag()
        {
            Assert.Equal(Tag.Ongoing, translator.ToTag("ongoing"));
        }

        [Fact]
        public void EpisodeNumberToTag()
        {
            Assert.Equal(Tag.Episode, translator.ToTag("1"));
        }

        [Fact]
        public void ReleaseToTag()
        {
            Assert.Equal(Tag.Release, translator.ToTag("release"));
        }

        [Fact]
        public void JJJToTag_ExceptionExpected()
        {
            Assert.Throws<ArgumentException>(() => translator.ToTag("jjjjj"));
        }

        [Fact]
        public void EpisodeStringToTag_ExceptionExpected()
        {
            Assert.Throws<ArgumentException>(() => translator.ToTag("episode"));
        }
    }
}
