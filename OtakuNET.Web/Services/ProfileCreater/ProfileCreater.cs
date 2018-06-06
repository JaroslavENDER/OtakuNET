using OtakuNET.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OtakuNET.Web.Services.ProfileCreater
{
    public class ProfileCreater : IProfileCreater
    {
        public Profile Create(string id, string login)
        {
            return new Profile
            {
                Id = id,
                Login = login,
                History = new List<ProfileHistoryItem>
                {
                    new ProfileHistoryItem
                    {
                        Timestamp = DateTime.Now,
                        Text = "Зарегистрировался на сайте"
                    }
                },
                AnimeListSet = new List<UserAnimeList>
                    {
                        new UserAnimeList
                        {
                            Key = "a-planed",
                            Name = "Запланировано",
                        },
                        new UserAnimeList
                        {
                            Key = "a-watching",
                            Name = "Смотрю",
                        },
                        new UserAnimeList
                        {
                            Key = "a-rewatching",
                            Name = "Пересматриваю",
                        },
                        new UserAnimeList
                        {
                            Key = "a-completed",
                            Name = "Просмотрено",
                        },
                        new UserAnimeList
                        {
                            Key = "a-paused",
                            Name = "Отложено",
                        },
                        new UserAnimeList
                        {
                            Key = "a-droped",
                            Name = "Брошено",
                        }
                    },
                MangaListSet = new List<UserMangaList>
                    {
                        new UserMangaList
                        {
                            Key = "m-planed",
                            Name = "Запланировано",
                        },
                        new UserMangaList
                        {
                            Key = "m-watching",
                            Name = "Читаю",
                        },
                        new UserMangaList
                        {
                            Key = "m-rewatching",
                            Name = "Перечитываю",
                        },
                        new UserMangaList
                        {
                            Key = "m-completed",
                            Name = "Прочитано",
                        },
                        new UserMangaList
                        {
                            Key = "m-paused",
                            Name = "Отложено",
                        },
                        new UserMangaList
                        {
                            Key = "m-droped",
                            Name = "Брошено",
                        }
                    }
            };
        }
    }
}
