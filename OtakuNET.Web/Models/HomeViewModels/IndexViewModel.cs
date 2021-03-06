﻿using OtakuNET.Web.Models.AnimangaViewModels;
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
        public List<RecomendationInfoViewModel> AnimeRecomendationsFirstBlock { get; set; }
        public List<RecomendationInfoViewModel> AnimeRecomendationsSecondBlock { get; set; }
        public List<RecomendationInfoViewModel> MangaRecomendationsFirstBlock { get; set; }
        public List<RecomendationInfoViewModel> MangaRecomendationsSecondBlock { get; set; }
    }
}
