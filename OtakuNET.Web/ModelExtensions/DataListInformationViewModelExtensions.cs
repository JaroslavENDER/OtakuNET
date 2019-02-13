using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions
{
    public static class DataListInformationViewModelExtensions
    {
        public static List<DataListInformationViewModel> Initialize(this List<DataListInformationViewModel> model, List<DataListInformation> info)
        {
            model.AddRange(info.GroupBy(i => i.Name)
                    .Select(group => new DataListInformationViewModel
                    {
                        Key = group.Key,
                        Values = group.Select(g => g.Value).ToList()
                    }));
            return model;
        }
    }
}
