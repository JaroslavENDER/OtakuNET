using OtakuNET.Web.Models.AnimangaViewModels;
using System.Collections.Generic;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class TitleInUserListsViewModelExtensions
    {
        /// <summary>
        /// Fake initializator
        /// </summary>
        public static TitleInUserListsViewModel Initialize(this TitleInUserListsViewModel model)
        {
            model.InUserLists = new Dictionary<string, int>
            {
                ["Запланировано"] = 8112,
                ["Смотрю"] = 7343,
                ["Пересматриваю"] = 98,
                ["Просмотрено"] = 0,
                ["Отложено"] = 24,
                ["Брошено"] = 4
            };

            return model;
        }
    }
}
