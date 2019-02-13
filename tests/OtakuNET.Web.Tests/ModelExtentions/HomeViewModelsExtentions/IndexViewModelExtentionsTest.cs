using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.HomeViewModelsExtentions;
using OtakuNET.Web.Models.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OtakuNET.Web.Tests.ModelExtentions.HomeViewModelsExtentions
{
    public class IndexViewModelExtentionsTest
    {
        [Fact]
        public void Returns8OngoingsWithLatestUpdateCreatedAt()
        {
            var ongoings = new List<Title>
            {
                new Title
                {
                    Name = "Мегалобокс",
                    Updates = new List<TitleUpdate>
                    {
                        new TitleUpdate
                        {
                            CreatedAt = DateTime.Now.AddMonths(-1),
                        }
                    }
                },
                new Title
                {
                    Name = "Семь смертных грехов",
                    Updates = new List<TitleUpdate>
                    {
                        new TitleUpdate
                        {
                            CreatedAt = DateTime.Now.AddDays(-25),
                        }
                    }
                },
                new Title
            {
                Name = "Трусливый велосипедист",
                Updates = new List<TitleUpdate>
                {
                    new TitleUpdate
                    {
                        CreatedAt = DateTime.Now.AddDays(-8),
                    }
                }
            },
                new Title
                {
                    Name = "Хладнокровный Казуки",
                    Updates = new List<TitleUpdate>
                    {
                        new TitleUpdate
                        {
                            CreatedAt = DateTime.Now.AddDays(-7),
                        }
                    }
                },
                new Title
                {
                    Name = "Старшая школа DxD",
                    Updates = new List<TitleUpdate>
                    {
                        new TitleUpdate
                        {
                            CreatedAt = DateTime.Now.AddDays(-6),
                        }
                    }
                },
                new Title
                {
                    Name = "Второй Мейджор",
                    Updates = new List<TitleUpdate>
                    {
                        new TitleUpdate
                        {
                            CreatedAt = DateTime.Now.AddDays(-1),
                        }
                    }
                },
                new Title
                {
                    Name = "Хисонэ и Масо",
                    Updates = new List<TitleUpdate>
                    {
                        new TitleUpdate
                        {
                            CreatedAt = DateTime.Now.AddHours(-2),
                        }
                    }
                },
                new Title
                {
                    Name = "Персона 5",
                    Updates = new List<TitleUpdate>
                    {
                        new TitleUpdate
                        {
                            CreatedAt = DateTime.Now.AddMinutes(-30),
                        }
                    }
                },
                new Title
                {
                    Name = "Повар-боец Сома: Третье блюдо - Часть II",
                    Updates = new List<TitleUpdate>
                    {
                        new TitleUpdate
                        {
                            CreatedAt = DateTime.Now,
                        }
                    }
                }
            };

            var result = new IndexViewModel().Initialize(string.Empty, ongoings, null, null, new List<AnimeSeason>());

            Assert.Equal(8, result.Ongoings.Count);
            Assert.Null(result.Ongoings.FirstOrDefault(a => a.Name == "Мегалобокс"));
        }

        [Fact]
        public void ReturnsDefaultUserListsFromNulls()
        {
            var result = new IndexViewModel().Initialize(string.Empty, new List<Title>(), null, null, new List<AnimeSeason>());

            Assert.Equal(6, result.UserAnimeLists.Count);
            Assert.Equal(6, result.UserMangaLists.Count);
            Assert.Equal("Запланировано", result.UserMangaLists.First().Name);
            Assert.Equal("Просмотрено", result.UserAnimeLists[3].Name);
        }
    }
}
