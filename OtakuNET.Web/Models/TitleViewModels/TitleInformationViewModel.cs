using System.Collections.Generic;

namespace OtakuNET.Web.Models.TitleViewModels
{
    public class TitleInformationViewModel
    {
        public Tag Tag { get; set; }
        public List<DataListInformationViewModel> Information { get; set; }
    }
}
