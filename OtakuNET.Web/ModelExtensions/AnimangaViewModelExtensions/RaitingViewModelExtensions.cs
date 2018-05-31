using OtakuNET.Web.Models.AnimangaViewModels;
using System.Collections.Generic;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class RaitingViewModelExtensions
    {
        /// <summary>
        /// Fake initializator
        /// </summary>
        public static RaitingViewModel Initialize(this RaitingViewModel model, double raiting)
        {
            model.CurrentUserRaiting = 0;
            model.Raiting = raiting;
            model.UserAssessments = new Dictionary<int, int>
            {
                [10] = 902,
                [9] = 855,
                [8] = 809,
                [7] = 700,
                [6] = 693
            };

            return model;
        }
    }
}
