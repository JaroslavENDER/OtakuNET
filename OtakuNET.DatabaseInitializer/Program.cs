using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using OtakuNET.Domain.Enums;

namespace OtakuNET.DatabaseInitializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OtakuNET-20180611;Trusted_Connection=True;MultipleActiveResultSets=true");
            var dbContext = new EfDbContext(options.Options);
            try
            {
                InitializeDatabase(dbContext);
                AddComments(dbContext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Done.");
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private static void InitializeDatabase(IDbContext dbContext)
        {
            var leto = new AnimeSeason
            {
                Key = "leto2019",
                Name = "Летний сезон",
                FullName = "Летний сезон 2019 года"
            };
            var vesna = new AnimeSeason
            {
                Key = "vesna2019",
                Name = "Весенний сезон",
                FullName = "Весенний сезон 2019 года"
            };
            var zima = new AnimeSeason
            {
                Key = "zima2018",
                Name = "Зимний сезон",
                FullName = "Зимний сезон 2018 года"
            };
            dbContext.Seasons.AddRange(new[]
            {
                new AnimeSeason
                {
                    Key = "vesna2018",
                    Name = "Весенний сезон",
                    FullName = "Весенний сезон 2018 года"
                },
                new AnimeSeason
                {
                    Key = "leto2018",
                    Name = "Летний сезон",
                    FullName = "Летний сезон 2018 года"
                },
                new AnimeSeason
                {
                    Key = "osen2018",
                    Name = "Осенний сезон",
                    FullName = "Осенний сезон 2018 года"
                },
                zima,
                vesna,
                leto
            });
            var megalobox = new Title
            {
                Key = "megalobox",
                Name = "Мегалобокс",
                ImageSrc = "https://desu.shikimori.org/system/animes/original/36563.jpg?1524534309",
                Rating = 8.41,
                StudioName = "TMS Entertaiment",
                StudioImageSrc = "https://shikimori.org/system/studios/original/73.?1413190852",
                Tag = "ongoing",
                AnimeSeason = vesna,
                Description = "Не имеющий идентификационной карты юноша по кличке JD (Junk Dog) участвует в подпольных боях на боксёрском ринге. За неимением выбора он использует единственный свой талант как средство для заработка в договорных матчах под руководством тренера Намбу, но жаждет схлестнуться с настоящими профи на легальной основе. На его удачу, в ближайшем мегаполисе собирается проходить беспрецедентное, по меркам любого боксёра, мероприятие — «Мегалония», собирающее на своей арене лучших из лучших, движимых желанием получить звание «сильнейшего». Конечно же, наш герой хочет во что бы то ни стало туда попасть, чтобы доказать самому себе, чего на самом деле стоит его жизнь.",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "8 / 13"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 5 апр. 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Экшен"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Драмма"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Спорт"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "R-17"
                    }
                }
            };
            var sevenDeathestBagActions = new Title
            {
                Key = "seven-deathest-bad-actions",
                Name = "Семь смертных грехов",
                ImageSrc = "https://moe.shikimori.org/system/animes/original/34577.jpg?1524426711",
                Rating = 7.94,
                StudioName = "A-1 Pictures Inc.",
                StudioImageSrc = "https://shikimori.org/system/studios/original/56.?1434707196",
                Tag = "ongoing",
                AnimeSeason = vesna,
                Description = "«Семь Смертных Грехов». Давным-давно так называли семь могущественных рыцарей, обвинявшихся в сговоре, целью которого было свергнуть короля Британии. Воины были казнены благородным орденом Священных Рыцарей, однако ходят слухи, что «Семь Грехов» всё ещё живы. \nДесять лет спустя Священные Рыцари устроили государственный переворот и вероломно убили короля, установив собственную тиранию в стране.Элизабет, третья дочь короля, отправляется на поиски «Семи Смертных Грехов», дабы, заручившись их поддержкой, вернуть в страну закон и справедливость.Итак,путешествие начинается...",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "5 / 24"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 13 янв. 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Экшен"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Приключения"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Сверхъестественное"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var cryingCyclist = new Title
            {
                Key = "crying-cyclist",
                Name = "Трусливый велосипедист",
                ImageSrc = "https://dere.shikimori.org/system/animes/original/35789.jpg?1524471359",
                Rating = 7.86,
                StudioName = "TMS Entertaiment",
                StudioImageSrc = "https://shikimori.org/system/studios/original/73.?1413190852",
                Tag = "ongoing",
                AnimeSeason = vesna,
                Description = "Onoda Sakamichi's team, Sohoku High School, won last year's national tournament, the Inter-High. The upperclassmen who pulled the team have graduated. By inspiring, supporting, and lifting each other up, the new generation of team members won a ticket to the Inter-High and a chance at a repeat championship. Their rivals, Hakone Academy, former champions seeking to reclaim their crown, and Kyoto Fushimi, home to the monstrous racer Midousuji, have gathered at the race, where they'll clash in a fierce battle for victory! Every racer carries his hopes and dreams in his heart. As sprinters who race along straight lines, climbers who are masters of the mountains, and aces who lead their teams to victory... The \"GLORY LINE\" is each racer's finish line of honor and glory, but who will be the first to cross it?!",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "21 / 25"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "23 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 8 янв. 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Драмма"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Сенен"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var coldBloodKazuki = new Title
            {
                Key = "cold-blood-kazuki",
                Name = "Хладнокровный Казуки",
                ImageSrc = "https://dere.shikimori.org/system/animes/original/37029.jpg?1524543379",
                Rating = 7.8,
                StudioName = "Studio DEEN",
                StudioImageSrc = "https://shikimori.org/system/studios/original/37.?1434707541",
                Tag = "ongoing",
                AnimeSeason = vesna,
                Description = "",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "8 / 13"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "23 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 8 апр. 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Демоны"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Фэнтези"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var higestSchoolDxD = new Title
            {
                Key = "higest-school-dxd",
                Name = "Старшая школа DxD",
                ImageSrc = "https://kawai.shikimori.org/system/animes/original/34281.jpg?1524528930",
                Rating = 7.52,
                StudioName = "Passione",
                StudioImageSrc = "https://shikimori.org/system/studios/original/911.jpg?1402343502",
                Tag = "ongoing",
                AnimeSeason = vesna,
                Description = "В конце третьего сезона Локи был побеждён. Но теперь семье Риас Гремори предстоит сражение с новым противником — Сайраоргом. Герои усердно трудятся, чтобы попасть в высшее сословие демонов.",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "7 / 12"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "23 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 5 июня 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Экшен"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Школа"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "R+"
                    }
                }
            };
            var secondMaidJoo = new Title
            {
                Key = "second-maid-joo",
                Name = "Второй Мейджор",
                ImageSrc = "https://nyaa.shikimori.org/system/animes/original/36565.jpg?1524536113",
                Rating = 7.59,
                StudioName = "NHK Enterprises",
                StudioImageSrc = "",
                Tag = "ongoing",
                AnimeSeason = vesna,
                Description = "Daigo is born as the son of Gorou, a father who is too great. What path will Daigo, who is burdened with great expectations, take in baseball?",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "8 / ?"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 7 апр. 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Спорт"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Драмма"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var hisoneAndMaco = new Title
            {
                Key = "hisone-and-maco",
                Name = "Хисонэ и Масо",
                ImageSrc = "https://dere.shikimori.org/system/animes/original/36884.jpg?1524527111",
                Rating = 7.5,
                StudioName = "Bones",
                StudioImageSrc = "https://shikimori.org/system/studios/original/4.png?1311292711",
                Tag = "ongoing",
                AnimeSeason = vesna,
                Description = "Простодушный и наивный новобранец Хисонэ Амакасу прибывает на базу ВВС сил самообороны Японии. Девушка вступила в ряды ВВС, чтобы держаться на расстоянии от окружающих, ведь всю свою жизнь она умудрялась даже совсем невинными словами обижать и причинять боль близким ей людям. Это решение Хисонэ стало судьбоносным и привело к встрече с драконом типа «OTF», который может превращаться в боевой истребитель. Дракон, сокрытый на базе, выбрал Амакасу своим пилотом, кардинально изменив её судьбу. Легенды гласят, что у драконов есть ключ к будущему мира... Вместе с Хисонэ и другими драго-пилотами нам предстоит выяснить, правда ли это!",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "7 / ?"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 12 апр. 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Военное"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Драмма"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var persona5 = new Title
            {
                Key = "persona5",
                Name = "Персона 5",
                ImageSrc = "https://desu.shikimori.org/system/animes/original/36023.jpg?1524543344",
                Rating = 7.17,
                StudioName = "A-1 Pictures Inc.",
                StudioImageSrc = "",
                Tag = "ongoing",
                AnimeSeason = vesna,
                Description = "Старшеклассник Рэн Амамия становится свидетелем домогательства. Недолго думая Рэн бросается на мужчину, который нагло прижимает к стене красивую девушку, несмотря на её громкие протесты. И хотя исход драки завершился в пользу Рэна, ему не повезло — нападавший оказался влиятельным политиком. Из-за этого факта, а также из-за того, что спасённая им девушка отказалась давать показания, главного героя судят за хулиганство и в качестве меры наказания назначают испытательный срок на один год. После этого ему приходится переехать в Токио и поступить в новую школу. \nВ столице Рэн ютится на чердаке в кафе «Leblanc», хозяином которого является старый друг его родителей, согласившийся на время поселить у себя парня.Уже в первый день в новом городе Рэн обнаруживает у себя на смартфоне загадочное приложение.А по дороге в новую школу юноша знакомится со своим одноклассником Рюджи Сакамото, причём при весьма странных обстоятельствах: Рэн и Рюджи попадают в удивительный альтернативный мир — «Дворец», где их пытается убить странный человек, похожий на местного учителя физкультуры, а Рэн пробуждает в себе нечто под названием Персона. Сумев сбежать из «Дворца» и снова оказавшись в реальном Токио, друзья решают разобраться в происходящем и воздать учителю физкультуры по заслугам.",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "8 / 12"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 7 апр. 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Экшен"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Сверхъестественное"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Фэнтези"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "PG-17"
                    }
                }
            };
            var somasKitchen = new Title
            {
                Key = "somas-kitchen",
                Name = "Повар-боец Сома: Третье блюдо - Часть II",
                ImageSrc = "",
                Rating = 8.56,
                StudioName = "J.C. Staff",
                StudioImageSrc = "https://shikimori.org/system/studios/original/7.?1434707490",
                Tag = "ongoing",
                AnimeSeason = vesna,
                Description = "Отец Эрины Накири, Азами, как и хотел, встал на пост директора кулинарной академии. С его приходом всё изменилось: правила стали жёстче, плохих учеников сразу выгоняют, а с теми, кто против изменений, обращаются крайне плохо. Сама же Эрина сбежала из дома и прячется в общежитии, где живёт Сома. Теперь девушка решила встать против тирании отца, дабы спасти своих друзей от участи предстоящих экзаменов, проводимых по всему Хоккайдо.",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "8 / 12"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 8 апр. 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Этти"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Школа"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Сенен"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var island = new Title
            {
                Key = "island",
                Name = "Остров",
                ImageSrc = "",
                StudioName = "feet.",
                StudioImageSrc = "https://shikimori.org/system/studios/original/91.png?1350322172",
                Tag = "announce",
                AnimeSeason = leto,
                Description = "События разворачивается на острове Урасима, который находится далеко от материка. \nВ прошлом люди, живущие на этом острове, вели совсем беззаботную жизнь.Но пять лет назад три великие семьи острова потерпели ряд неудач, из - за чего на них обрушилось много подозрений со стороны жителей.Люди начали обрывать все связи с материком, и вся культура острова пришла в упадок.Ключ к спасению острова таится в трех девушках, принадлежащих этим семействам.Но они связаны древними традициями и не должны конфликтовать между собой. \nВ это непростое время на берег острова выбрасывает одинокого мужчину.Без имени, но с четким стремлением — он утверждает, что прибыл из будущего, чтобы помочь, и начинает одинокую борьбу ради изменения судьбы Урасимы.",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "OVA"
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "на июль 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Фантастика"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Драма"
                    }
                }
            };
            var kempingOnFreshAir = new Title
            {
                Key = "kemping-on-fresh-air",
                Name = "Лагерь на свежем воздухе",
                ImageSrc = "https://desu.shikimori.org/system/animes/original/34798.jpg?1520779534",
                Rating = 8.35,
                StudioName = "C-Station",
                StudioImageSrc = "",
                Tag = "release",
                AnimeSeason = zima,
                Description = "Рин не первый год приезжает к подножию горы Фудзи. Там, поставив палатку, она живет прямо в лесу, созерцает открывающийся ей вид и пользуется всеми дарами природы, которые только сможет найти — таково ее хобби. \nВо время очередной такой поездки происходит судьбоносная встреча с не менее странной и непоседливой девчушкой Надэсико, которая приехала посмотреть на гору, потому что ее пейзаж был изображен на купюре значимостью в тысячу иен.",
                Links = new List<TitleLink>
                {
                    new TitleLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new TitleLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<TitleInformation>
                {
                    new TitleInformation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new TitleInformation
                    {
                        Name = "Эпизоды",
                        Value = "12"
                    },
                    new TitleInformation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new TitleInformation
                    {
                        Name = "Статус",
                        Value = "с 4 янв. по 22 марта 2019 г."
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Повседневность"
                    },
                    new TitleInformation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new TitleInformation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            dbContext.Titles.AddRange(new[]
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
            dbContext.TitleUpdates.AddRange(new[]
            {
                new TitleUpdate
                {
                    Title = megalobox,
                    Tag = "announce",
                    CreatedAt = DateTime.Now.AddMonths(-1),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "PG-13" },
                        new TitleInformation { Name = "Жанры", Value = "Боевые искуства" },
                        new TitleInformation { Name = "Жанры", Value = "Приключения" },
                        new TitleInformation { Name = "Жанры", Value = "Драмма" },
                    }
                },
                new TitleUpdate
                {
                    Title = sevenDeathestBagActions,
                    Tag = "1",
                    CreatedAt = DateTime.Now.AddDays(-25),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "PG-13" },
                        new TitleInformation { Name = "Эпизоды", Value = "1 / ?" },
                        new TitleInformation { Name = "Жанры", Value = "Приключения" },
                        new TitleInformation { Name = "Жанры", Value = "Драмма" },
                    }
                },
                new TitleUpdate
                {
                    Title = cryingCyclist,
                    Tag = "2",
                    CreatedAt = DateTime.Now.AddDays(-8),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "G" },
                        new TitleInformation { Name = "Эпизоды", Value = "2 / 12" },
                        new TitleInformation { Name = "Жанры", Value = "Приключения" },
                        new TitleInformation { Name = "Жанры", Value = "Повседневность" },
                    }
                },
                new TitleUpdate
                {
                    Title = coldBloodKazuki,
                    Tag = "2",
                    CreatedAt = DateTime.Now.AddDays(-7),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "G" },
                        new TitleInformation { Name = "Эпизоды", Value = "2 / 12" },
                        new TitleInformation { Name = "Жанры", Value = "Приключения" },
                        new TitleInformation { Name = "Жанры", Value = "Повседневность" },
                        new TitleInformation { Name = "Жанры", Value = "Экшен" },
                    }
                },
                new TitleUpdate
                {
                    Title = higestSchoolDxD,
                    Tag = "5",
                    CreatedAt = DateTime.Now.AddDays(-6),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "G" },
                        new TitleInformation { Name = "Эпизоды", Value = "5 / 12" },
                        new TitleInformation { Name = "Жанры", Value = "Повседневность" },
                        new TitleInformation { Name = "Жанры", Value = "Экшен" },
                        new TitleInformation { Name = "Жанры", Value = "Этти" },
                    }
                },
                new TitleUpdate
                {
                    Title = secondMaidJoo,
                    Tag = "announce",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "PG-13" },
                        new TitleInformation { Name = "Жанры", Value = "Повседневность" },
                        new TitleInformation { Name = "Жанры", Value = "Этти" },
                        new TitleInformation { Name = "Жанры", Value = "Сенен Ай" },
                    }
                },
                new TitleUpdate
                {
                    Title = hisoneAndMaco,
                    Tag = "announce",
                    CreatedAt = DateTime.Now.AddHours(-2),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "ONA" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "PG-13" },
                        new TitleInformation { Name = "Жанры", Value = "Повседневность" }
                    }
                },
                new TitleUpdate
                {
                    Title = persona5,
                    Tag = "10",
                    CreatedAt = DateTime.Now.AddMinutes(-30),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "PG-13" },
                        new TitleInformation { Name = "Эпизоды", Value = "10 / 12" },
                        new TitleInformation { Name = "Жанры", Value = "Повседневность" },
                        new TitleInformation { Name = "Жанры", Value = "Экшен" },
                        new TitleInformation { Name = "Жанры", Value = "Мистика" }
                    }
                },
                new TitleUpdate
                {
                    Title = somasKitchen,
                    Tag = "12",
                    CreatedAt = DateTime.Now.AddSeconds(-50),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "PG-13" },
                        new TitleInformation { Name = "Эпизоды", Value = "12 / 24" },
                        new TitleInformation { Name = "Жанры", Value = "Повседневность" },
                        new TitleInformation { Name = "Жанры", Value = "Сенен" },
                        new TitleInformation { Name = "Жанры", Value = "Этти" },
                        new TitleInformation { Name = "Жанры", Value = "Школа" }
                    }
                },
                new TitleUpdate
                {
                    Title = island,
                    Tag = "announce",
                    CreatedAt = DateTime.Now.AddSeconds(-30),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2019 год" },
                        new TitleInformation { Name = "Тип", Value = "PG-13" },
                        new TitleInformation { Name = "Жанры", Value = "Выживание" },
                        new TitleInformation { Name = "Жанры", Value = "Сенен" },
                        new TitleInformation { Name = "Жанры", Value = "Драма" }
                    }
                },
                new TitleUpdate
                {
                    Title = kempingOnFreshAir,
                    Tag = "12",
                    CreatedAt = DateTime.Now.AddYears(-1).AddSeconds(-12),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2018 год" },
                        new TitleInformation { Name = "Тип", Value = "PG-13" },
                        new TitleInformation { Name = "Эпизоды", Value = "12 / 12" },
                        new TitleInformation { Name = "Жанры", Value = "Выживание" },
                        new TitleInformation { Name = "Жанры", Value = "В лесу" },
                        new TitleInformation { Name = "Жанры", Value = "Повседневность" }
                    }
                },
                new TitleUpdate
                {
                    Title = kempingOnFreshAir,
                    Tag = "release",
                    CreatedAt = DateTime.Now.AddYears(-1),
                    Information = new List<TitleInformation>
                    {
                        new TitleInformation { Name = "Тип", Value = "TV Сериал" },
                        new TitleInformation { Name = "Тип", Value = "2018 год" },
                        new TitleInformation { Name = "Тип", Value = "PG-13" },
                        new TitleInformation { Name = "Эпизоды", Value = "12" },
                        new TitleInformation { Name = "Жанры", Value = "Выживание" },
                        new TitleInformation { Name = "Жанры", Value = "В лесу" },
                        new TitleInformation { Name = "Жанры", Value = "Повседневность" }
                    }
                }
            });
            dbContext.News.AddRange(new[]
            {
                new News
                {
                    Title = "Старкон в Петербурге",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    Tag = "news",
                    ImageSrc = "",
                    Text = "10 и 11 июня в Петербурге пройдёт ежегодный международный фестиваль фантастики, кино и науки — Старкон. Как и в прошлом году, “Старкон” пройдет в конгрессно-выставочном центре «Экспофорум». Всего в этом году ожидается больше 1300 косплееров из России и стран ближнего зарубежья. На главной сцене вы увидите зрелищные выступления косплееров и грандиозную шоу-программу."
                },
                new News
                {
                    Title = "Маньхуа «Magmel of the Sea Blue» получит экранизацию",
                    CreatedAt = DateTime.Now.AddHours(-12),
                    Tag = "news",
                    ImageSrc = "https://nyaa.shikimori.org/system/user_images/preview/136187/589235.jpg",
                    Text = "Компания Shueisha объявила, что маньхуа Magmel of the Sea Blue будет экранизирована. Также, стала известна команда, которая будет работать над адаптацией: Режиссёр — Хаято Датэ (Наруто: Ураганные хроники, Парни из магазинчика); Сценарист — Тюдзи Микасано(Токийский гуль, Токийский гуль √A); Музыка — Ясухару Таканаси (Сказка о Хвосте феи, Усопшие); Студия производства — Pierrot."
                },
                new News
                {
                    Title = "Промо ролик телеканала \"FAN\" и другие подробности.",
                    CreatedAt = DateTime.Now,
                    Tag = "news",
                    ImageSrc = "https://kawai.shikimori.org/system/user_images/preview/33635/590241.jpg",
                    Text = "Формат вещания: 16:9 / HD / Stereo.\nFAN — единственный в России телеканал, показывающий анимационное и игровое кино в жанре фэнтези и фантастики. Нарисованные миры, альтернативные реальности,наделенные сверхспособностями супергерои, яркие эмоции и новые впечатления — основа привлечения новой, самой большой потенциальной аудитории. В эфире телеканала — популярный и востребованный контент: культовые картины от основоположников жанра японских производителей"
                }
            });

            var customUserList = new UserList
            {
                Key = "custom-list",
                Name = "Кастомный список",
                Description = "Список с двумя аниме, созданный пользователем",
                TitleList = new List<TitleUserList>
                {
                    new TitleUserList
                    {
                        Title = kempingOnFreshAir
                    },
                    new TitleUserList
                    {
                        Title = somasKitchen
                    }
                }
            };

            var profile = new Profile
            {
                Login = "JaroslavENDER",
                Name = "Ender",
                Avatar = null,
                UserLists = new List<UserList>
                    {
                        new UserList
                        {
                            Type = TitleType.Anime,
                            Key = "a-planed",
                            Name = "Запланировано",
                        },
                        new UserList
                        {
                            Type = TitleType.Anime,
                            Key = "a-watching",
                            Name = "Смотрю",
                        },
                        new UserList
                        {
                            Type = TitleType.Anime,
                            Key = "a-rewatching",
                            Name = "Пересматриваю",
                        },
                        new UserList
                        {
                            Type = TitleType.Anime,
                            Key = "a-completed",
                            Name = "Просмотрено",
                            TitleList = new List<TitleUserList>
                            {
                                new TitleUserList
                                {
                                    Title = kempingOnFreshAir
                                }
                            }
                        },
                        new UserList
                        {
                            Type = TitleType.Anime,
                            Key = "a-paused",
                            Name = "Отложено",
                        },
                        new UserList
                        {
                            Type = TitleType.Anime,
                            Key = "a-droped",
                            Name = "Брошено",
                        },
                        customUserList,
                        new UserList
                        {
                            Type = TitleType.Manga,
                            Key = "m-planed",
                            Name = "Запланировано",
                        },
                        new UserList
                        {
                            Type = TitleType.Manga,
                            Key = "m-watching",
                            Name = "Читаю",
                        },
                        new UserList
                        {
                            Type = TitleType.Manga,
                            Key = "m-rewatching",
                            Name = "Перечитываю",
                        },
                        new UserList
                        {
                            Type = TitleType.Manga,
                            Key = "m-completed",
                            Name = "Прочитано",
                        },
                        new UserList
                        {
                            Type = TitleType.Manga,
                            Key = "m-paused",
                            Name = "Отложено",
                        },
                        new UserList
                        {
                            Type = TitleType.Manga,
                            Key = "m-droped",
                            Name = "Брошено",
                        }
                    },
                History = new List<ProfileHistoryItem>
                    {
                        new ProfileHistoryItem
                        {
                            CreatedAt = DateTime.Now.AddDays(-4),
                            Text = "Зарегистрировался на сайте"
                        },
                        new ProfileHistoryItem
                        {
                            CreatedAt = DateTime.Now.AddDays(-2),
                            Text = "Добавлено в список",
                            Title = somasKitchen,
                            UserList = customUserList
                        },
                        new ProfileHistoryItem
                        {
                            CreatedAt = DateTime.Now.AddDays(-2),
                            Text = "Добавлено в список",
                            Title = kempingOnFreshAir,
                            UserList = customUserList
                        },
                        new ProfileHistoryItem
                        {
                            CreatedAt = DateTime.Now.AddSeconds(-30),
                            Text = "Просмотрено",
                            Title = kempingOnFreshAir
                        }
                    }
            };
            dbContext.Profiles.Add(profile);


            dbContext.SaveChanges();
        }

        private static void AddComments(IDbContext dbContext)
        {
            var profile = dbContext.Profiles.FirstOrDefault(p => p.Login == "JaroslavENDER");
            var somasKitchen = dbContext.Titles.FirstOrDefault(t => t.Key == "somas-kitchen");

            profile.Comments.AddRange(new[]
            {
                new Comment
                {
                    Title = somasKitchen,
                    CreatedAt = DateTime.Now,
                    Text = "First comment to anime Soma`s kitchen"
                },
                new Comment
                {
                    Title = somasKitchen,
                    CreatedAt = DateTime.Now.AddSeconds(20),
                    Text = "Second comment to anime Soma`s kitchen"
                }
            });

            dbContext.SaveChanges();
        }
    }
}
