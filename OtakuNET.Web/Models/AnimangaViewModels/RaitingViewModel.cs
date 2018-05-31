using System.Collections.Generic;

namespace OtakuNET.Web.Models.AnimangaViewModels
{
    public class RaitingViewModel
    {
        public Dictionary<int, int> UserAssessments { get; set; }
        public double Raiting { get; set; }
        public double CurrentUserRaiting { get; set; }
    }
}
