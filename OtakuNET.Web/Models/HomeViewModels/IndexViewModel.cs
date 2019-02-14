using OtakuNET.Web.Models.TitleViewModels;
using OtakuNET.Web.Models.ProfileViewModels;
using System.Collections.Generic;

namespace OtakuNET.Web.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public string Login { get; set; }
        public List<TitlePreviewViewModel> Ongoings { get; set; }
        public List<UserListInfoViewModel> UserAnimeLists { get; set; }
        public List<UserListInfoViewModel> UserMangaLists { get; set; }
        public List<RecomendationInfoViewModel> AnimeRecommendationsFirstBlock { get; set; }
        public List<RecomendationInfoViewModel> AnimeRecommendationsSecondBlock { get; set; }
        public List<RecomendationInfoViewModel> MangaRecommendationsFirstBlock { get; set; }
        public List<RecomendationInfoViewModel> MangaRecommendationsSecondBlock { get; set; }
    }
}
