using OtakuNET.Web.Models;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;
using System;
using Xunit;

namespace OtakuNET.Web.Tests.Services
{
    public class TagTranslatorEngToStringTest
    {
        private ITagTranslator translator = new TagTranslatorEng();

        [Fact]
        public void NewsToString()
        {
            Assert.Equal("news", translator.ToString(Tag.News));
        }

        [Fact]
        public void AnnounceToString()
        {
            Assert.Equal("announce", translator.ToString(Tag.Announce));
        }

        [Fact]
        public void OngoingToString()
        {
            Assert.Equal("ongoing", translator.ToString(Tag.Ongoing));
        }

        [Fact]
        public void EpisodeToString()
        {
            Assert.Throws<InvalidOperationException>(() => translator.ToString(Tag.Episode));
        }

        [Fact]
        public void ReleaseToString()
        {
            Assert.Equal("release", translator.ToString(Tag.Release));
        }
    }
}
