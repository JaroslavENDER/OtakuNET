using OtakuNET.Web.Models;

namespace OtakuNET.Web.Services.TagTranslator.Frontend
{
    public interface IFrontendTagTranslator : ITagTranslator
    {
        string ToClassName(Tag tag);
        string ToEpisodeString(string tagInfo);
    }
}
