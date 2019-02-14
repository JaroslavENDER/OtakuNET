using System.Collections.Generic;

namespace OtakuNET.Web.Models.TitleViewModels
{
    public class RatingViewModel
    {
        public Dictionary<int, int> UserAssessments { get; set; }
        public double Rating { get; set; }
        public double CurrentUserRating { get; set; }
    }
}
