using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.AnimangaViewModels;
using OtakuNET.Web.Models.HomeViewModels;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Models.ProfileViewModels;
using OtakuNET.Web.Services;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.HomeViewModelsExtentions
{
    public static class IndexViewModelExtensions
    {
        public static IndexViewModel Initialize(this IndexViewModel model,
            List<Anime> ongoings,
            List<UserAnimeList> userAnimeLists,
            List<UserMangaList> userMangaList,
            List<AnimeSeason> lastSeasons,
            List<News> lastNews,
            List<Update> lastUpdates,
            ITimestampFormatter timestampFormatter,
            ITagTranslator tagTranslator)
        {
            model.Ongoings = ongoings
                .OrderByDescending(a => a.Updates.Max(u => u.Timestamp))
                .Take(8)
                .Select(a => new TitlePreviewViewModel
                {
                    Key = a.Key,
                    Name = a.Title,
                    Info = a.StudioName,
                    ImageSrc = a.ImageSrc
                })
                .ToList();

            model.UserAnimeLists = userAnimeLists?.Count > 0
                ? userAnimeLists
                    .Select(ual => new UserListInfoViewModel
                    {
                        Name = ual.Name,
                        TitleCount = ual.Anime.Count,
                        Description = ual.Description
                    })
                    .ToList()
                : new List<UserListInfoViewModel>
                {
                    new UserListInfoViewModel{ TitleCount = 0, Name = "Запланировано", Description = string.Empty },
                    new UserListInfoViewModel{ TitleCount = 0, Name = "Смотрю", Description = string.Empty },
                    new UserListInfoViewModel{ TitleCount = 0, Name = "Пересматриваю", Description = string.Empty },
                    new UserListInfoViewModel{ TitleCount = 0, Name = "Просмотрено", Description = string.Empty },
                    new UserListInfoViewModel{ TitleCount = 0, Name = "Отложено", Description = string.Empty },
                    new UserListInfoViewModel{ TitleCount = 0, Name = "Брошено", Description = string.Empty }
                };

            model.UserMangaLists = userMangaList?.Count > 0
                ? userMangaList
                    .Select(uml => new UserListInfoViewModel
                    {
                        Name = uml.Name,
                        TitleCount = uml.Manga.Count,
                        Description = uml.Description
                    })
                    .ToList()
                : new List<UserListInfoViewModel>
                {
                        new UserListInfoViewModel{ TitleCount = 0, Name = "Запланировано", Description = string.Empty },
                        new UserListInfoViewModel{ TitleCount = 0, Name = "Читаю", Description = string.Empty },
                        new UserListInfoViewModel{ TitleCount = 0, Name = "Перечитываю", Description = string.Empty },
                        new UserListInfoViewModel{ TitleCount = 0, Name = "Прочитано", Description = string.Empty },
                        new UserListInfoViewModel{ TitleCount = 0, Name = "Отложено", Description = string.Empty },
                        new UserListInfoViewModel{ TitleCount = 0, Name = "Брошено", Description = string.Empty }
                };

            model.AnimeRecomendationsFirstBlock = lastSeasons.Skip(lastSeasons.Count - 4).Select(n => new RecomendationInfoViewModel { Text = n.Name, Link = n.Key, LinkTitle = n.FullName }).ToList();
            model.AnimeRecomendationsSecondBlock = new List<RecomendationInfoViewModel>
            {
                new RecomendationInfoViewModel
                {
                    Text = "Избранное",
                    Link = "",
                    LinkTitle = "Избранное"
                },
                new RecomendationInfoViewModel
                {
                    Text = "От сообщества",
                    Link = "",
                    LinkTitle = "От сообщества"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Персонализированные",
                    Link = "",
                    LinkTitle = "Персонализированные"
                }
            };
            model.MangaRecomendationsFirstBlock = new List<RecomendationInfoViewModel>
            {
                new RecomendationInfoViewModel
                {
                    Text = "Манга",
                    Link = "",
                    LinkTitle = "Манга"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Ваншот",
                    Link = "",
                    LinkTitle = "Ваншот"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Додзинси",
                    Link = "",
                    LinkTitle = "Додзинси"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Маньхуа",
                    Link = "",
                    LinkTitle = "Маньхуа"
                }
            };
            model.MangaRecomendationsSecondBlock = new List<RecomendationInfoViewModel>
            {
                new RecomendationInfoViewModel
                {
                    Text = "Избранное",
                    Link = "",
                    LinkTitle = "Избранное"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Персонализированные",
                    Link = "",
                    LinkTitle = "Персонализированные"
                }
            };

            model.News = lastNews
                .Select(n => new OneNewsViewModel
                {
                    Title = n.Title,
                    Timestamp = timestampFormatter.Format(n.Timestamp),
                    ImageSrc = n.ImageSrc,
                    Text = n.Text
                })
                .ToList();
            model.Updates = lastUpdates.Take(8) //TODO: remove Take(8)
                .Select(u => new OneUpdateViewModel
                {
                    Title = u.Anime.Title,
                    Tag = tagTranslator.ToTag(u.Tag),
                    //TagInfo = u.Tag,
                    Timestamp = timestampFormatter.Format(u.Timestamp),
                    ImageSrc = u.Anime.ImageSrc
                })
                .ToList();

            return model;
        }
    }
}
