using Moq;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.HomeViewModelsExtentions;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.HomeViewModels;
using OtakuNET.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OtakuNET.Web.Tests.ModelExtentions.HomeViewModelsExtentions
{
    public class IndexViewModelExtentionsTest
    {
        [Fact]
        public void Returns8OngoingsWithLatestUpdateTimestamp()
        {
            var ongoings = new List<Anime>
            {
                new Anime
                {
                    Title = "Мегалобокс",
                    Updates = new List<Update>
                    {
                        new Update
                        {
                            Timestamp = DateTime.Now.AddMonths(-1),
                        }
                    }
                },
                new Anime
                {
                    Title = "Семь смертных грехов",
                    Updates = new List<Update>
                    {
                        new Update
                        {
                            Timestamp = DateTime.Now.AddDays(-25),
                        }
                    }
                },
                new Anime
            {
                Title = "Трусливый велосипедист",
                Updates = new List<Update>
                {
                    new Update
                    {
                        Timestamp = DateTime.Now.AddDays(-8),
                    }
                }
            },
                new Anime
                {
                    Title = "Хладнокровный Казуки",
                    Updates = new List<Update>
                    {
                        new Update
                        {
                            Timestamp = DateTime.Now.AddDays(-7),
                        }
                    }
                },
                new Anime
                {
                    Title = "Старшая школа DxD",
                    Updates = new List<Update>
                    {
                        new Update
                        {
                            Timestamp = DateTime.Now.AddDays(-6),
                        }
                    }
                },
                new Anime
                {
                    Title = "Второй Мейджор",
                    Updates = new List<Update>
                    {
                        new Update
                        {
                            Timestamp = DateTime.Now.AddDays(-1),
                        }
                    }
                },
                new Anime
                {
                    Title = "Хисонэ и Масо",
                    Updates = new List<Update>
                    {
                        new Update
                        {
                            Timestamp = DateTime.Now.AddHours(-2),
                        }
                    }
                },
                new Anime
                {
                    Title = "Персона 5",
                    Updates = new List<Update>
                    {
                        new Update
                        {
                            Timestamp = DateTime.Now.AddMinutes(-30),
                        }
                    }
                },
                new Anime
                {
                    Title = "Повар-боец Сома: Третье блюдо - Часть II",
                    Updates = new List<Update>
                    {
                        new Update
                        {
                            Timestamp = DateTime.Now,
                        }
                    }
                }
            };
            var timestampFormatterMock = new Mock<ITimestampFormatter>();
            timestampFormatterMock.Setup(m => m.Format(It.IsAny<DateTime>())).Returns<DateTime>(dt => dt.ToLongDateString());
            var tagTranslatorMock = new Mock<ITagTranslator>();
            tagTranslatorMock.Setup(m => m.ToTag(It.IsAny<string>())).Returns<string>(tag => Tag.Release);

            var result = new IndexViewModel().Initialize(ongoings, null, null, new List<AnimeSeason>(), new List<News>(), new List<Update>(), timestampFormatterMock.Object, tagTranslatorMock.Object);

            Assert.Equal(8, result.Ongoings.Count);
            Assert.Null(result.Ongoings.FirstOrDefault(a => a.Name == "Мегалобокс"));
        }

        [Fact]
        public void ReturnsDefaultUserListsFromNulls()
        {
            var timestampFormatterMock = new Mock<ITimestampFormatter>();
            timestampFormatterMock.Setup(m => m.Format(It.IsAny<DateTime>())).Returns<DateTime>(dt => dt.ToLongDateString());
            var tagTranslatorMock = new Mock<ITagTranslator>();
            tagTranslatorMock.Setup(m => m.ToTag(It.IsAny<string>())).Returns<string>(tag => Tag.Release);

            var result = new IndexViewModel().Initialize(new List<Anime>(), null, null, new List<AnimeSeason>(), new List<News>(), new List<Update>(), timestampFormatterMock.Object, tagTranslatorMock.Object);

            Assert.Equal(6, result.UserAnimeLists.Count);
            Assert.Equal(6, result.UserMangaLists.Count);
            Assert.Equal("Запланировано", result.UserMangaLists.First().Name);
            Assert.Equal("Просмотрено", result.UserAnimeLists[3].Name);
        }
    }
}
