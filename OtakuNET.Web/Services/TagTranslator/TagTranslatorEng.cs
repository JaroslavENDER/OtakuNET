using OtakuNET.Web.Models;
using System;

namespace OtakuNET.Web.Services
{
    public class TagTranslatorEng : ITagTranslator
    {
        public string ToString(Tag tag)
        {
            if (tag == Tag.Episode)
                throw new InvalidOperationException();
            if (tag == Tag.News)
                return "news";
            if (tag == Tag.Announce)
                return "announce";
            if (tag == Tag.Ongoing)
                return "ongoing";
            if (tag == Tag.Release)
                return "release";

            throw new ArgumentException($"Недопустимый параметр {tag}");
        }
        public Tag ToTag(string tag)
        {
            if (tag == "news")
                return Tag.News;
            if (tag == "announce")
                return Tag.Announce;
            if (tag == "ongoing")
                return Tag.Ongoing;
            if (int.TryParse(tag, out var x))
                return Tag.Episode;
            if (tag == "release")
                return Tag.Release;

            throw new ArgumentException($"Недопустимый параметр {tag}");
        }
    }
}
