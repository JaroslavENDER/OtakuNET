using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models;

namespace OtakuNET.Web.ModelExtensions
{
    public static class LinkViewModelExtensions
    {
        public static LinkViewModel Initialize(this LinkViewModel model, TitleLink link)
        {
            model.Text = link.Text;
            model.Href = link.Href;

            return model;
        }
    }
}
