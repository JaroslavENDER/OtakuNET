using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.Models.NewsViewModels
{
    public class OneUpdateViewModel : OneNewsBaseViewModel
    {
        public List<IGrouping<string, string>> Info { get; set; }
    }
}
