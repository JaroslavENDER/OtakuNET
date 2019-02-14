using OtakuNET.Web.Models.TitleViewModels;
using System.Collections.Generic;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class RatingViewModelExtensions
    {
        /// <summary>
        /// Fake initializator
        /// </summary>
        public static RatingViewModel Initialize(this RatingViewModel model, double Rating)
        {
            model.CurrentUserRating = 0;
            model.Rating = Rating;
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
