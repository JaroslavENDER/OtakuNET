﻿using OtakuNET.Web.Models;
using OtakuNET.Web.Services.TagTranslator;
using System;
using Xunit;

namespace OtakuNET.Web.Tests.Services
{
    public class TagTranslatorToStringTest
    {
        private ITagTranslator translator = new TagTranslator();

        [Fact]
        public void NewsToString()
        {
            Assert.Equal("новость", translator.ToString(Tag.News));
        }

        [Fact]
        public void AnnounceToString()
        {
            Assert.Equal("анонс", translator.ToString(Tag.Announce));
        }

        [Fact]
        public void OngoingToString()
        {
            Assert.Equal("онгоинг", translator.ToString(Tag.Ongoing));
        }

        [Fact]
        public void EpisodeToString()
        {
            Assert.Throws<InvalidOperationException>(() => translator.ToString(Tag.Episode));
        }

        [Fact]
        public void ReleaseToString()
        {
            Assert.Equal("релиз", translator.ToString(Tag.Release));
        }
    }
}
