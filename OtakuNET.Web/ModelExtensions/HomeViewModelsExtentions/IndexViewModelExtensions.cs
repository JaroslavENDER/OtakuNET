using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions;
using OtakuNET.Web.Models.AnimangaViewModels;
using OtakuNET.Web.Models.HomeViewModels;
using OtakuNET.Web.Models.ProfileViewModels;
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
            List<AnimeSeason> seasons)
        {
            model.Ongoings = ongoings
                .OrderByDescending(a => a.Updates.Max(u => u.Timestamp))
                .Take(8)
                .Select(a => new TitlePreviewViewModel().Initialize(a))
                .ToList();

            model.UserAnimeLists = userAnimeLists?.Count > 0
                ? userAnimeLists
                    .Select(ual => new UserListInfoViewModel().Initialize(ual))
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
                    .Select(uml => new UserListInfoViewModel().Initialize(uml))
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

            model.AnimeRecomendationsFirstBlock = seasons.Skip(seasons.Count - 4).Select(n => new RecomendationInfoViewModel { Text = n.Name, Href = $"/Anime/Season/{n.Key}", LinkTitle = n.FullName }).ToList();
            model.AnimeRecomendationsSecondBlock = new List<RecomendationInfoViewModel>
            {
                new RecomendationInfoViewModel
                {
                    Text = "Избранное",
                    Href = "",
                    LinkTitle = "Избранное"
                },
                new RecomendationInfoViewModel
                {
                    Text = "От сообщества",
                    Href = "",
                    LinkTitle = "От сообщества"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Персонализированные",
                    Href = "",
                    LinkTitle = "Персонализированные"
                }
            };
            model.MangaRecomendationsFirstBlock = new List<RecomendationInfoViewModel>
            {
                new RecomendationInfoViewModel
                {
                    Text = "Манга",
                    Href = "",
                    LinkTitle = "Манга"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Ваншот",
                    Href = "",
                    LinkTitle = "Ваншот"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Додзинси",
                    Href = "",
                    LinkTitle = "Додзинси"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Маньхуа",
                    Href = "",
                    LinkTitle = "Маньхуа"
                }
            };
            model.MangaRecomendationsSecondBlock = new List<RecomendationInfoViewModel>
            {
                new RecomendationInfoViewModel
                {
                    Text = "Избранное",
                    Href = "",
                    LinkTitle = "Избранное"
                },
                new RecomendationInfoViewModel
                {
                    Text = "Персонализированные",
                    Href = "",
                    LinkTitle = "Персонализированные"
                }
            };

            return model;
        }
    }
}
