using System.Collections.Generic;

namespace OtakuNET.Web.Models.NewsViewModels
{
    public class OneUpdateViewModel : OneNewsBaseViewModel
    {
        public string TitleKey { get; set; }
        public List<DataListInformationViewModel> Info { get; set; }
    }
}
