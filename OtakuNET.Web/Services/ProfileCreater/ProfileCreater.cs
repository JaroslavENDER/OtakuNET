using OtakuNET.Domain.Entities;
using System;
using System.Collections.Generic;
using OtakuNET.Domain.Enums;

namespace OtakuNET.Web.Services.ProfileCreater
{
    public class ProfileCreater : IProfileCreater
    {
        public Profile Create(string applicationUserId, string login)
        {
            return new Profile
            {
                ApplicationUserId = applicationUserId,
                Login = login,
                History = new List<ProfileHistoryItem>
                {
                    new ProfileHistoryItem
                    {
                        CreatedAt = DateTime.Now,
                        Text = "Зарегистрировался на сайте"
                    }
                },
                UserListSet = new List<UserList>
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
                    }
            };
        }
    }
}
