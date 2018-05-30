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
                ImageSrc = "https://desu.shikimori.org/system/animes/preview/36563.jpg?1524534309",
                Raiting = 8.41,
                StudioName = "TMS Entertaiment",
                StudioImageSrc = "https://shikimori.org/system/studios/original/73.?1413190852",
                Tag = "ongoing",
                Season = vesna,
                Description = "Не имеющий идентификационной карты юноша по кличке JD (Junk Dog) участвует в подпольных боях на боксёрском ринге. За неимением выбора он использует единственный свой талант как средство для заработка в договорных матчах под руководством тренера Намбу, но жаждет схлестнуться с настоящими профи на легальной основе. На его удачу, в ближайшем мегаполисе собирается проходить беспрецедентное, по меркам любого боксёра, мероприятие — «Мегалония», собирающее на своей арене лучших из лучших, движимых желанием получить звание «сильнейшего». Конечно же, наш герой хочет во что бы то ни стало туда попасть, чтобы доказать самому себе, чего на самом деле стоит его жизнь.",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "8 / 13"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 5 апр. 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Экшен"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Драмма"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Спорт"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "R-17"
                    }
                }
            };
            var sevenDeathestBagActions = new Anime
            {
                Key = "seven-deathest-bad-actions",
                Title = "Семь смертных грехов",
                ImageSrc = "https://moe.shikimori.org/system/animes/preview/34577.jpg?1524426711",
                Raiting = 7.94,
                StudioName = "A-1 Pictures Inc.",
                StudioImageSrc = "https://shikimori.org/system/studios/original/56.?1434707196",
                Tag = "ongoing",
                Season = vesna,
                Description = "«Семь Смертных Грехов». Давным-давно так называли семь могущественных рыцарей, обвинявшихся в сговоре, целью которого было свергнуть короля Британии. Воины были казнены благородным орденом Священных Рыцарей, однако ходят слухи, что «Семь Грехов» всё ещё живы. \nДесять лет спустя Священные Рыцари устроили государственный переворот и вероломно убили короля, установив собственную тиранию в стране.Элизабет, третья дочь короля, отправляется на поиски «Семи Смертных Грехов», дабы, заручившись их поддержкой, вернуть в страну закон и справедливость.Итак,путешествие начинается...",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "5 / 24"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 13 янв. 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Экшен"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Приключения"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Сверхъестественное"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var cryingCyclist = new Anime
            {
                Key = "crying-cyclist",
                Title = "Трусливый велосипедист",
                ImageSrc = "https://dere.shikimori.org/system/animes/preview/35789.jpg?1524471359",
                Raiting = 7.86,
                StudioName = "TMS Entertaiment",
                StudioImageSrc = "https://shikimori.org/system/studios/original/73.?1413190852",
                Tag = "ongoing",
                Season = vesna,
                Description = "Onoda Sakamichi's team, Sohoku High School, won last year's national tournament, the Inter-High. The upperclassmen who pulled the team have graduated. By inspiring, supporting, and lifting each other up, the new generation of team members won a ticket to the Inter-High and a chance at a repeat championship. Their rivals, Hakone Academy, former champions seeking to reclaim their crown, and Kyoto Fushimi, home to the monstrous racer Midousuji, have gathered at the race, where they'll clash in a fierce battle for victory! Every racer carries his hopes and dreams in his heart. As sprinters who race along straight lines, climbers who are masters of the mountains, and aces who lead their teams to victory... The \"GLORY LINE\" is each racer's finish line of honor and glory, but who will be the first to cross it?!",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "21 / 25"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "23 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 8 янв. 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Драмма"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Сенен"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var coldBloodKazuki = new Anime
            {
                Key = "cold-blood-kazuki",
                Title = "Хладнокровный Казуки",
                ImageSrc = "https://dere.shikimori.org/system/animes/preview/37029.jpg?1524543379",
                Raiting = 7.8,
                StudioName = "Studio DEEN",
                StudioImageSrc = "https://shikimori.org/system/studios/original/37.?1434707541",
                Tag = "ongoing",
                Season = vesna,
                Description = "",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "8 / 13"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "23 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 8 апр. 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Демоны"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Фэнтези"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var higestSchoolDxD = new Anime
            {
                Key = "higest-school-dxd",
                Title = "Старшая школа DxD",
                ImageSrc = "https://kawai.shikimori.org/system/animes/preview/34281.jpg?1524528930",
                Raiting = 7.52,
                StudioName = "Passione",
                StudioImageSrc = "https://shikimori.org/system/studios/original/911.jpg?1402343502",
                Tag = "ongoing",
                Season = vesna,
                Description = "В конце третьего сезона Локи был побеждён. Но теперь семье Риас Гремори предстоит сражение с новым противником — Сайраоргом. Герои усердно трудятся, чтобы попасть в высшее сословие демонов.",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "7 / 12"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "23 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 5 июня 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Экшен"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Школа"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "R+"
                    }
                }
            };
            var secondMaidJoo = new Anime
            {
                Key = "second-maid-joo",
                Title = "Второй Мейджор",
                ImageSrc = "https://nyaa.shikimori.org/system/animes/preview/36565.jpg?1524536113",
                Raiting = 7.59,
                StudioName = "NHK Enterprises",
                StudioImageSrc = "",
                Tag = "ongoing",
                Season = vesna,
                Description = "Daigo is born as the son of Gorou, a father who is too great. What path will Daigo, who is burdened with great expectations, take in baseball?",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "8 / ?"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 7 апр. 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Спорт"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Драмма"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var hisoneAndMaco = new Anime
            {
                Key = "hisone-and-maco",
                Title = "Хисонэ и Масо",
                ImageSrc = "https://dere.shikimori.org/system/animes/preview/36884.jpg?1524527111",
                Raiting = 7.5,
                StudioName = "Bones",
                StudioImageSrc = "https://shikimori.org/system/studios/original/4.png?1311292711",
                Tag = "ongoing",
                Season = vesna,
                Description = "Простодушный и наивный новобранец Хисонэ Амакасу прибывает на базу ВВС сил самообороны Японии. Девушка вступила в ряды ВВС, чтобы держаться на расстоянии от окружающих, ведь всю свою жизнь она умудрялась даже совсем невинными словами обижать и причинять боль близким ей людям. Это решение Хисонэ стало судьбоносным и привело к встрече с драконом типа «OTF», который может превращаться в боевой истребитель. Дракон, сокрытый на базе, выбрал Амакасу своим пилотом, кардинально изменив её судьбу. Легенды гласят, что у драконов есть ключ к будущему мира... Вместе с Хисонэ и другими драго-пилотами нам предстоит выяснить, правда ли это!",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "7 / ?"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 12 апр. 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Военное"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Драмма"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var persona5 = new Anime
            {
                Key = "persona5",
                Title = "Персона 5",
                ImageSrc = "https://desu.shikimori.org/system/animes/preview/36023.jpg?1524543344",
                Raiting = 7.17,
                StudioName = "A-1 Pictures Inc.",
                StudioImageSrc = "",
                Tag = "ongoing",
                Season = vesna,
                Description = "Старшеклассник Рэн Амамия становится свидетелем домогательства. Недолго думая Рэн бросается на мужчину, который нагло прижимает к стене красивую девушку, несмотря на её громкие протесты. И хотя исход драки завершился в пользу Рэна, ему не повезло — нападавший оказался влиятельным политиком. Из-за этого факта, а также из-за того, что спасённая им девушка отказалась давать показания, главного героя судят за хулиганство и в качестве меры наказания назначают испытательный срок на один год. После этого ему приходится переехать в Токио и поступить в новую школу. \nВ столице Рэн ютится на чердаке в кафе «Leblanc», хозяином которого является старый друг его родителей, согласившийся на время поселить у себя парня.Уже в первый день в новом городе Рэн обнаруживает у себя на смартфоне загадочное приложение.А по дороге в новую школу юноша знакомится со своим одноклассником Рюджи Сакамото, причём при весьма странных обстоятельствах: Рэн и Рюджи попадают в удивительный альтернативный мир — «Дворец», где их пытается убить странный человек, похожий на местного учителя физкультуры, а Рэн пробуждает в себе нечто под названием Персона. Сумев сбежать из «Дворца» и снова оказавшись в реальном Токио, друзья решают разобраться в происходящем и воздать учителю физкультуры по заслугам.",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "8 / 12"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 7 апр. 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Экшен"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Сверхъестественное"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Фэнтези"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "PG-17"
                    }
                }
            };
            var somasKitchen = new Anime
            {
                Key = "somas-kitchen",
                Title = "Повар-боец Сома: Третье блюдо - Часть II",
                ImageSrc = "",
                Raiting = 8.56,
                StudioName = "J.C. Staff",
                StudioImageSrc = "https://shikimori.org/system/studios/original/7.?1434707490",
                Tag = "ongoing",
                Season = vesna,
                Description = "Отец Эрины Накири, Азами, как и хотел, встал на пост директора кулинарной академии. С его приходом всё изменилось: правила стали жёстче, плохих учеников сразу выгоняют, а с теми, кто против изменений, обращаются крайне плохо. Сама же Эрина сбежала из дома и прячется в общежитии, где живёт Сома. Теперь девушка решила встать против тирании отца, дабы спасти своих друзей от участи предстоящих экзаменов, проводимых по всему Хоккайдо.",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "MyAnimeList",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "8 / 12"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 8 апр. 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Этти"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Школа"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Сенен"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
            };
            var island = new Anime
            {
                Key = "island",
                Title = "Остров",
                ImageSrc = "",
                StudioName = "feet.",
                StudioImageSrc = "https://shikimori.org/system/studios/original/91.png?1350322172",
                Tag = "announce",
                Season = leto,
                Description = "События разворачивается на острове Урасима, который находится далеко от материка. \nВ прошлом люди, живущие на этом острове, вели совсем беззаботную жизнь.Но пять лет назад три великие семьи острова потерпели ряд неудач, из - за чего на них обрушилось много подозрений со стороны жителей.Люди начали обрывать все связи с материком, и вся культура острова пришла в упадок.Ключ к спасению острова таится в трех девушках, принадлежащих этим семействам.Но они связаны древними традициями и не должны конфликтовать между собой. \nВ это непростое время на берег острова выбрасывает одинокого мужчину.Без имени, но с четким стремлением — он утверждает, что прибыл из будущего, чтобы помочь, и начинает одинокую борьбу ради изменения судьбы Урасимы.",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "OVA"
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "на июль 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Фантастика"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Драма"
                    }
                }
            };
            var kempingOnFreshAir = new Anime
            {
                Key = "kemping-on-fresh-air",
                Title = "Лагерь на свежем воздухе",
                ImageSrc = "https://desu.shikimori.org/system/animes/preview/34798.jpg?1520779534",
                Raiting = 8.35,
                StudioName = "C-Station",
                StudioImageSrc = "",
                Tag = "release",
                Season = zima,
                Description = "Рин не первый год приезжает к подножию горы Фудзи. Там, поставив палатку, она живет прямо в лесу, созерцает открывающийся ей вид и пользуется всеми дарами природы, которые только сможет найти — таково ее хобби. \nВо время очередной такой поездки происходит судьбоносная встреча с не менее странной и непоседливой девчушкой Надэсико, которая приехала посмотреть на гору, потому что ее пейзаж был изображен на купюре значимостью в тысячу иен.",
                Links = new List<AnimangaLink>
                {
                    new AnimangaLink
                    {
                        Text = "Официальный сайт",
                        Href = ""
                    },
                    new AnimangaLink
                    {
                        Text = "AniDUB",
                        Href = ""
                    }
                },
                Information = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизоды",
                        Value = "12"
                    },
                    new DataListInfomation
                    {
                        Name = "Длительность эпизода",
                        Value = "24 мин."
                    },
                    new DataListInfomation
                    {
                        Name = "Статус",
                        Value = "с 4 янв. по 22 марта 2018 г."
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Повседневность"
                    },
                    new DataListInfomation
                    {
                        Name = "Жанры",
                        Value = "Комедия"
                    },
                    new DataListInfomation
                    {
                        Name = "Рейтинг",
                        Value = "PG-13"
                    }
                }
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
                    Tag = "announce",
                    Timestamp = DateTime.Now.AddMonths(-1),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "PG-13" },
                        new DataListInfomation { Name = "Жанры", Value = "Боевые искуства" },
                        new DataListInfomation { Name = "Жанры", Value = "Приключения" },
                        new DataListInfomation { Name = "Жанры", Value = "Драмма" },
                    }
                },
                new Update
                {
                    Anime = sevenDeathestBagActions,
                    Tag = "1",
                    Timestamp = DateTime.Now.AddDays(-25),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "PG-13" },
                        new DataListInfomation { Name = "Эпизоды", Value = "1 / ?" },
                        new DataListInfomation { Name = "Жанры", Value = "Приключения" },
                        new DataListInfomation { Name = "Жанры", Value = "Драмма" },
                    }
                },
                new Update
                {
                    Anime = cryingCyclist,
                    Tag = "2",
                    Timestamp = DateTime.Now.AddDays(-8),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "G" },
                        new DataListInfomation { Name = "Эпизоды", Value = "2 / 12" },
                        new DataListInfomation { Name = "Жанры", Value = "Приключения" },
                        new DataListInfomation { Name = "Жанры", Value = "Повседневность" },
                    }
                },
                new Update
                {
                    Anime = coldBloodKazuki,
                    Tag = "2",
                    Timestamp = DateTime.Now.AddDays(-7),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "G" },
                        new DataListInfomation { Name = "Эпизоды", Value = "2 / 12" },
                        new DataListInfomation { Name = "Жанры", Value = "Приключения" },
                        new DataListInfomation { Name = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Name = "Жанры", Value = "Экшен" },
                    }
                },
                new Update
                {
                    Anime = higestSchoolDxD,
                    Tag = "5",
                    Timestamp = DateTime.Now.AddDays(-6),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "G" },
                        new DataListInfomation { Name = "Эпизоды", Value = "5 / 12" },
                        new DataListInfomation { Name = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Name = "Жанры", Value = "Экшен" },
                        new DataListInfomation { Name = "Жанры", Value = "Этти" },
                    }
                },
                new Update
                {
                    Anime = secondMaidJoo,
                    Tag = "announce",
                    Timestamp = DateTime.Now.AddDays(-1),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "PG-13" },
                        new DataListInfomation { Name = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Name = "Жанры", Value = "Этти" },
                        new DataListInfomation { Name = "Жанры", Value = "Сенен Ай" },
                    }
                },
                new Update
                {
                    Anime = hisoneAndMaco,
                    Tag = "announce",
                    Timestamp = DateTime.Now.AddHours(-2),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "ONA" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "PG-13" },
                        new DataListInfomation { Name = "Жанры", Value = "Повседневность" }
                    }
                },
                new Update
                {
                    Anime = persona5,
                    Tag = "10",
                    Timestamp = DateTime.Now.AddMinutes(-30),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "PG-13" },
                        new DataListInfomation { Name = "Эпизоды", Value = "10 / 12" },
                        new DataListInfomation { Name = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Name = "Жанры", Value = "Экшен" },
                        new DataListInfomation { Name = "Жанры", Value = "Мистика" }
                    }
                },
                new Update
                {
                    Anime = somasKitchen,
                    Tag = "12",
                    Timestamp = DateTime.Now.AddSeconds(-50),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "PG-13" },
                        new DataListInfomation { Name = "Эпизоды", Value = "12 / 24" },
                        new DataListInfomation { Name = "Жанры", Value = "Повседневность" },
                        new DataListInfomation { Name = "Жанры", Value = "Сенен" },
                        new DataListInfomation { Name = "Жанры", Value = "Этти" },
                        new DataListInfomation { Name = "Жанры", Value = "Школа" }
                    }
                },
                new Update
                {
                    Anime = island,
                    Tag = "announce",
                    Timestamp = DateTime.Now.AddSeconds(-30),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2018 год" },
                        new DataListInfomation { Name = "Тип", Value = "PG-13" },
                        new DataListInfomation { Name = "Жанры", Value = "Выживание" },
                        new DataListInfomation { Name = "Жанры", Value = "Сенен" },
                        new DataListInfomation { Name = "Жанры", Value = "Драма" }
                    }
                },
                new Update
                {
                    Anime = kempingOnFreshAir,
                    Tag = "12",
                    Timestamp = DateTime.Now.AddYears(-1).AddSeconds(-12),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2017 год" },
                        new DataListInfomation { Name = "Тип", Value = "PG-13" },
                        new DataListInfomation { Name = "Эпизоды", Value = "12 / 12" },
                        new DataListInfomation { Name = "Жанры", Value = "Выживание" },
                        new DataListInfomation { Name = "Жанры", Value = "В лесу" },
                        new DataListInfomation { Name = "Жанры", Value = "Повседневность" }
                    }
                },
                new Update
                {
                    Anime = kempingOnFreshAir,
                    Tag = "release",
                    Timestamp = DateTime.Now.AddYears(-1),
                    Infomation = new List<DataListInfomation>
                    {
                        new DataListInfomation { Name = "Тип", Value = "TV Сериал" },
                        new DataListInfomation { Name = "Тип", Value = "2017 год" },
                        new DataListInfomation { Name = "Тип", Value = "PG-13" },
                        new DataListInfomation { Name = "Эпизоды", Value = "12" },
                        new DataListInfomation { Name = "Жанры", Value = "Выживание" },
                        new DataListInfomation { Name = "Жанры", Value = "В лесу" },
                        new DataListInfomation { Name = "Жанры", Value = "Повседневность" }
                    }
                }
            });
            dbContext.News.AddRange(new[]
            {
                new News
                {
                    Title = "Старкон в Петербурге",
                    Timestamp = DateTime.Now.AddDays(-1),
                    Tag = "news",
                    ImageSrc = "",
                    Text = "10 и 11 июня в Петербурге пройдёт ежегодный международный фестиваль фантастики, кино и науки — Старкон. Как и в прошлом году, “Старкон” пройдет в конгрессно-выставочном центре «Экспофорум». Всего в этом году ожидается больше 1300 косплееров из России и стран ближнего зарубежья. На главной сцене вы увидите зрелищные выступления косплееров и грандиозную шоу-программу."
                },
                new News
                {
                    Title = "Маньхуа «Magmel of the Sea Blue» получит экранизацию",
                    Timestamp = DateTime.Now.AddHours(-12),
                    Tag = "news",
                    ImageSrc = "https://nyaa.shikimori.org/system/user_images/preview/136187/589235.jpg",
                    Text = "Компания Shueisha объявила, что маньхуа Magmel of the Sea Blue будет экранизирована. Также, стала известна команда, которая будет работать над адаптацией: Режиссёр — Хаято Датэ (Наруто: Ураганные хроники, Парни из магазинчика); Сценарист — Тюдзи Микасано(Токийский гуль, Токийский гуль √A); Музыка — Ясухару Таканаси (Сказка о Хвосте феи, Усопшие); Студия производства — Pierrot."
                },
                new News
                {
                    Title = "Промо ролик телеканала \"FAN\" и другие подробности.",
                    Timestamp = DateTime.Now,
                    Tag = "news",
                    ImageSrc = "https://kawai.shikimori.org/system/user_images/preview/33635/590241.jpg",
                    Text = "Формат вещания: 16:9 / HD / Stereo.\nFAN — единственный в России телеканал, показывающий анимационное и игровое кино в жанре фэнтези и фантастики. Нарисованные миры, альтернативные реальности,наделенные сверхспособностями супергерои, яркие эмоции и новые впечатления — основа привлечения новой, самой большой потенциальной аудитории. В эфире телеканала — популярный и востребованный контент: культовые картины от основоположников жанра японских производителей"
                }
            });

            dbContext.SaveChanges();
        }
    }
}
