using OtakuNET.Web.Models;
using System;

namespace OtakuNET.Web.Services.TagTranslator.Frontend
{
    public class FrontendTagTranslator : TagTranslator, IFrontendTagTranslator
    {
        public string ToClassName(Tag tag)
        {
            if (tag == Tag.News)
                return "tag--news";
            if (tag == Tag.Announce)
                return "tag--announce";
            if (tag == Tag.Ongoing)
                return "tag--ongoing";
            if (tag == Tag.Episode)
                return "tag--episode";
            if (tag == Tag.Release)
                return "tag--release";

            throw new ArgumentException($"Недопустимый параметр {tag}");
        }

        public string ToEpisodeString(string tagInfo)
        {
            if (!int.TryParse(tagInfo, out var x))
                throw new InvalidOperationException($"Недопустимый параметр {tagInfo}");
            return $"{tagInfo} эпизод";
        }
    }
}
