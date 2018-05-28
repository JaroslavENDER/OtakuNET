using OtakuNET.Web.Models;
using OtakuNET.Web.Services;
using System;
using Xunit;

namespace OtakuNET.Web.Tests.Services.TagTranslator
{
    public class TagTranslatorToTagTest
    {
        private ITagTranslator translator = new Web.Services.TagTranslator();

        [Fact]
        public void NewsToTag()
        {
            Assert.Equal(Tag.News, translator.ToTag("новость"));
        }

        [Fact]
        public void AnnounseToTag()
        {
            Assert.Equal(Tag.Announce, translator.ToTag("анонс"));
        }

        [Fact]
        public void OngoingToTag()
        {
            Assert.Equal(Tag.Ongoing, translator.ToTag("онгоинг"));
        }

        [Fact]
        public void EpisodeNumberToTag()
        {
            Assert.Equal(Tag.Episode, translator.ToTag("1"));
        }

        [Fact]
        public void ReleaseToTag()
        {
            Assert.Equal(Tag.Release, translator.ToTag("релиз"));
        }

        [Fact]
        public void JJJToTag_ExceptionExpected()
        {
            Assert.Throws<ArgumentException>(() => translator.ToTag("jjjjj"));
        }

        [Fact]
        public void EpisodeStringToTag_ExceptionExpected()
        {
            Assert.Throws<ArgumentException>(() => translator.ToTag("эпизод"));
        }
    }
}
