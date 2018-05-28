using OtakuNET.Web.Models;

namespace OtakuNET.Web.Services
{
    public interface ITagTranslator
    {
        string ToString(Tag tag);
        Tag ToTag(string tag);
    }
}
