using OtakuNET.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OtakuNET.Domain.DataProviders
{
    internal class StaticDbContextInitializer
    {
        public void Initialize(IDbContext dbContext)
        {
            var leto = new AnimeSeason
            {
                Key = "leto2018",
                Name = "Летний сезон",
                FullName = "Летний сезон 2018 года"
            };
            var vesna = new AnimeSeason
            {
                Key = "vesna2018",
                Name = "Весенний сезон",
                FullName = "Весенний сезон 2018 года"
            };
            var zima = new AnimeSeason
            {
                Key = "zima2017",
                Name = "Зимний сезон",
                FullName = "Зимний сезон 2017 года"
            };
            dbContext.Seasons.AddRange(new[]
            {
                new AnimeSeason
                {
                    Key = "vesna2017",
                    Name = "Весенний сезон",
                    FullName = "Весенний сезон 2017 года"
                },
                new AnimeSeason
                {
                    Key = "leto2017",
                    Name = "Летний сезон",
                    FullName = "Летний сезон 2017 года"
                },
                new AnimeSeason
                {
                    Key = "osen2017",
                    Name = "Осенний сезон",
                    FullName = "Осенний сезон 2017 года"
                },
                zima,
                vesna,
                leto
            });
            var megalobox = new Anime
            {
                Key = "megalobox",
                Title = "Мегалобокс",
                StudioName = "TMS Entertaiment",
                ImageSrc = "https://desu.shikimori.org/system/animes/preview/36563.jpg?1524534309",
                Season = vesna,
                Tag = "онгоинг"
            };
            var sevenDeathestBagActions = new Anime
            {
                Key = "seven-deathest-bad-actions",
                Title = "Семь смертных грехов",
                StudioName = "A-1 Pictures Inc.",
                ImageSrc = "https://moe.shikimori.org/system/animes/preview/34577.jpg?1524426711",
                Season = vesna,
                Tag = "онгоинг"
            };
            var cryingCyclist = new Anime
            {
                Key = "crying-cyclist",
                Title = "Трусливый велосипедист",
                StudioName = "TMS Entertaiment",
                ImageSrc = "https://dere.shikimori.org/system/animes/preview/35789.jpg?1524471359",
                Season = vesna,
                Tag = "онгоинг"
            };
            var coldBloodKazuki = new Anime
            {
                Key = "cold-blood-kazuki",
                Title = "Хладнокровный Казуки",
                StudioName = "Studio DEEN",
                ImageSrc = "https://dere.shikimori.org/system/animes/preview/37029.jpg?1524543379",
                Season = vesna,
                Tag = "онгоинг"
            };
            var higestSchoolDxD = new Anime
            {
                Key = "higest-school-dxd",
                Title = "Старшая школа DxD",
                StudioName = "Passione",
                ImageSrc = "https://kawai.shikimori.org/system/animes/preview/34281.jpg?1524528930",
                Season = vesna,
                Tag = "онгоинг"
            };
            var secondMaidJoo = new Anime
            {
                Key = "second-maid-joo",
                Title = "Второй Мейджор",
                StudioName = "NHK Enterprises",
                ImageSrc = "https://nyaa.shikimori.org/system/animes/preview/36565.jpg?1524536113",
                Season = vesna,
                Tag = "онгоинг"
            };
            var hisoneAndMaco = new Anime
            {
                Key = "hisone-and-maco",
                Title = "Хисонэ и Масо",
                StudioName = "Bones",
                ImageSrc = "https://dere.shikimori.org/system/animes/preview/36884.jpg?1524527111",
                Season = vesna,
                Tag = "онгоинг"
            };
            var persona5 = new Anime
            {
                Key = "persona5",
                Title = "Персона 5",
                StudioName = "A-1 Pictures Inc.",
                ImageSrc = "https://desu.shikimori.org/system/animes/preview/36023.jpg?1524543344",
                Season = vesna,
                Tag = "онгоинг"
            };
            var somasKitchen = new Anime
            {
                Key = "somas-kitchen",
                Title = "Повар-боец Сома: Третье блюдо - Часть II",
                StudioName = "J.C. Staff",
                ImageSrc = "",
                Season = vesna,
                Tag = "онгоинг"
            };
            var island = new Anime
            {
                Key = "island",
                Title = "Остров",
                StudioName = "feet.",
                ImageSrc = "",
                Season = leto,
                Tag = "анонс"
            };
            var kempingOnFreshAir = new Anime
            {
                Key = "kemping-on-fresh-air",
                Title = "Лагерь на свежем воздухе",
                StudioName = "C-Station",
                ImageSrc = "https://desu.shikimori.org/system/animes/preview/34798.jpg?1520779534",
                Season = zima,
                Tag = "релиз"
            };
            dbContext.Anime.AddRange(new[]
            {
                megalobox,
                sevenDeathestBagActions,
                cryingCyclist,
                coldBloodKazuki,
                higestSchoolDxD,
                secondMaidJoo,
                hisoneAndMaco,
                persona5,
                somasKitchen,
                island,
                kempingOnFreshAir
            });
            dbContext.Updates.AddRange(new[]
            {
                new Update
                {
                    Anime = megalobox,
                    Tag = "анонс",
                    Timestamp = DateTime.Now.AddMonths(-1),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "PG-13" },
                        new DataListInfomation { Key = "Жанры", Value = "Боевые искуства" },
                        new DataListInfomation { Key = "Жанры", Value = "Приключения" },
                        new DataListInfomation { Key = "Жанры", Value = "Драмма" },
                    }
                },
                new Update
                {
                    Anime = sevenDeathestBagActions,
                    Tag = "1",
                    Timestamp = DateTime.Now.AddDays(-25),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "PG-13" },
                        new DataListInfomation { Key = "Эпизоды", Value = "1 / ?" },
                        new DataListInfomation { Key = "Жанры", Value = "Приключения" },
                        new DataListInfomation { Key = "Жанры", Value = "Драмма" },
                    }
                },
                new Update
                {
                    Anime = cryingCyclist,
                    Tag = "2",
                    Timestamp = DateTime.Now.AddDays(-8),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "G" },
                        new DataListInfomation { Key = "Эпизоды", Value = "2 / 12" },
                        new DataListInfomation { Key = "Жанры", Value = "Приключения" },
                        new DataListInfomation { Key = "Жанры", Value = "Повседневность" },
                    }
                },
                new Update
                {
                    Anime = coldBloodKazuki,
                    Tag = "2",
                    Timestamp = DateTime.Now.AddDays(-7),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "G" },
                        new DataListInfomation { Key = "Эпизоды", Value = "2 / 12" },
                        new DataListInfomation { Key = "Жанры", Value = "Приключения" },
                        new DataListInfomation { Key = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Key = "Жанры", Value = "Экшен" },
                    }
                },
                new Update
                {
                    Anime = higestSchoolDxD,
                    Tag = "5",
                    Timestamp = DateTime.Now.AddDays(-6),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "G" },
                        new DataListInfomation { Key = "Эпизоды", Value = "5 / 12" },
                        new DataListInfomation { Key = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Key = "Жанры", Value = "Экшен" },
                        new DataListInfomation { Key = "Жанры", Value = "Этти" },
                    }
                },
                new Update
                {
                    Anime = secondMaidJoo,
                    Tag = "анонс",
                    Timestamp = DateTime.Now.AddDays(-1),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "PG-13" },
                        new DataListInfomation { Key = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Key = "Жанры", Value = "Этти" },
                        new DataListInfomation { Key = "Жанры", Value = "Сенен Ай" },
                    }
                },
                new Update
                {
                    Anime = hisoneAndMaco,
                    Tag = "анонс",
                    Timestamp = DateTime.Now.AddHours(-2),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "ONA" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "PG-13" },
                        new DataListInfomation { Key = "Жанры", Value = "Повседневность" }
                    }
                },
                new Update
                {
                    Anime = persona5,
                    Tag = "10",
                    Timestamp = DateTime.Now.AddMinutes(-30),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "PG-13" },
                        new DataListInfomation { Key = "Эпизоды", Value = "10 / 12" },
                        new DataListInfomation { Key = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Key = "Жанры", Value = "Экшен" },
                        new DataListInfomation { Key = "Жанры", Value = "Мистика" }
                    }
                },
                new Update
                {
                    Anime = somasKitchen,
                    Tag = "12",
                    Timestamp = DateTime.Now,
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "PG-13" },
                        new DataListInfomation { Key = "Эпизоды", Value = "12 / 24" },
                        new DataListInfomation { Key = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Key = "Жанры", Value = "Сенен" },
                        new DataListInfomation { Key = "Жанры", Value = "Этти" },
                        new DataListInfomation { Key = "Жанры", Value = "Школа" }
                    }
                },
                new Update
                {
                    Anime = island,
                    Tag = "анонс",
                    Timestamp = DateTime.Now.AddSeconds(3),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2018 год" },
                        new DataListInfomation { Key = "Тип", Value = "PG-13" },
                        new DataListInfomation { Key = "Жанры", Value = "Выживание" },
                        new DataListInfomation { Key = "Жанры", Value = "Сенен" },
                        new DataListInfomation { Key = "Жанры", Value = "Драма" }
                    }
                },
                new Update
                {
                    Anime = kempingOnFreshAir,
                    Tag = "12",
                    Timestamp = DateTime.Now.AddYears(1),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2017 год" },
                        new DataListInfomation { Key = "Тип", Value = "PG-13" },
                        new DataListInfomation { Key = "Эпизоды", Value = "12 / 12" },
                        new DataListInfomation { Key = "Жанры", Value = "Выживание" },
                        new DataListInfomation { Key = "Жанры", Value = "В лесу" },
                        new DataListInfomation { Key = "Жанры", Value = "Повседневность" }
                    }
                },
                new Update
                {
                    Anime = kempingOnFreshAir,
                    Tag = "релиз",
                    Timestamp = DateTime.Now.AddYears(1).AddSeconds(12),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Key = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Key = "Тип", Value = "2017 год" },
                        new DataListInfomation { Key = "Тип", Value = "PG-13" },
                        new DataListInfomation { Key = "Эпизоды", Value = "12" },
                        new DataListInfomation { Key = "Жанры", Value = "Выживание" },
                        new DataListInfomation { Key = "Жанры", Value = "В лесу" },
                        new DataListInfomation { Key = "Жанры", Value = "Повседневность" }
                    }
                }
            });
            dbContext.News.AddRange(new[]
            {
                new News
                {
                    Title = "Промо ролик телеканала \"FAN\" и другие подробности.",
                    Timestamp = DateTime.Now,
                    ImageSrc = "https://kawai.shikimori.org/system/user_images/preview/33635/590241.jpg",
                    Text = "Формат вещания: 16:9 / HD / Stereo.\nFAN — единственный в России телеканал, показывающий анимационное и игровое кино в жанре фэнтези и фантастики. Нарисованные миры, альтернативные реальности,наделенные сверхспособностями супергерои, яркие эмоции и новые впечатления — основа привлечения новой, самой большой потенциальной аудитории. В эфире телеканала — популярный и востребованный контент: культовые картины от основоположников жанра японских производителей"
                },
                new News
                {
                    Title = "Маньхуа «Magmel of the Sea Blue» получит экранизацию",
                    Timestamp = DateTime.Now.AddHours(12),
                    ImageSrc = "https://nyaa.shikimori.org/system/user_images/preview/136187/589235.jpg",
                    Text = "Компания Shueisha объявила, что маньхуа Magmel of the Sea Blue будет экранизирована. Также, стала известна команда, которая будет работать над адаптацией: Режиссёр — Хаято Датэ (Наруто: Ураганные хроники, Парни из магазинчика); Сценарист — Тюдзи Микасано(Токийский гуль, Токийский гуль √A); Музыка — Ясухару Таканаси (Сказка о Хвосте феи, Усопшие); Студия производства — Pierrot."
                },
                new News
                {
                    Title = "Старкон в Петербурге",
                    Timestamp = DateTime.Now.AddDays(1),
                    ImageSrc = "",
                    Text = "10 и 11 июня в Петербурге пройдёт ежегодный международный фестиваль фантастики, кино и науки — Старкон. Как и в прошлом году, “Старкон” пройдет в конгрессно-выставочном центре «Экспофорум». Всего в этом году ожидается больше 1300 косплееров из России и стран ближнего зарубежья. На главной сцене вы увидите зрелищные выступления косплееров и грандиозную шоу-программу."
                }
            });

            dbContext.SaveChanges();
        }
    }
}
