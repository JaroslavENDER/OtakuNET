using Ender.TimestampFormatterCore;
using Moq;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions;
using OtakuNET.Web.Models.ProfileViewModels;
using System;
using Xunit;

namespace OtakuNET.Web.Tests.ModelExtentions.ProfileViewModelsExtensions
{
    public class ProfileHistoryItemViewModelExtensionsTest
    {
        private ITimestampFormatter GetTimestampFormatter()
        {
            var timestampFormatterMock = new Mock<ITimestampFormatter>();
            timestampFormatterMock.Setup(m => m.Format(It.IsAny<DateTime>())).Returns<DateTime>(dt => dt.ToString());
            return timestampFormatterMock.Object;
        }

        [Fact]
        public void TitleIsNull()
        {
            var historyItem = new ProfileHistoryItem();

            var result = new ProfileHistoryItemViewModel().Initialize(historyItem, GetTimestampFormatter());

            Assert.Null(result.TitleInfo);
        }

        [Fact]
        public void HasAnimeTitle()
        {
            var historyItem = new ProfileHistoryItem
            {
                Anime = new Anime()
            };

            var result = new ProfileHistoryItemViewModel().Initialize(historyItem, GetTimestampFormatter());

            Assert.NotNull(result.TitleInfo);
        }

        [Fact]
        public void HasMangaTitle()
        {
            var historyItem = new ProfileHistoryItem
            {
                Manga = new Manga()
            };

            var result = new ProfileHistoryItemViewModel().Initialize(historyItem, GetTimestampFormatter());

            Assert.NotNull(result.TitleInfo);
        }

        [Fact]
        public void HasMangaTitleAndUserList()
        {
            var historyItem = new ProfileHistoryItem
            {
                Anime = new Anime(),
                UserList = new UserAnimeList()
            };

            var result = new ProfileHistoryItemViewModel().Initialize(historyItem, GetTimestampFormatter());

            Assert.NotNull(result.TitleInfo);
            Assert.NotNull(result.UserList);
        }
    }
}
