using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.AnimangaViewModels;
using System.Collections.Generic;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class TitleInformationViewModelExtensions
    {
        public static TitleInformationViewModel Initialize(this TitleInformationViewModel model, List<TitleInformation> info, Tag tag)
        {
            model.Information = new List<DataListInformationViewModel>().Initialize(info);
            model.Tag = tag;

            return model;
        }
    }
}
