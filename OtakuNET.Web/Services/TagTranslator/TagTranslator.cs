using OtakuNET.Web.Models;
using System;

namespace OtakuNET.Web.Services
{
    public class TagTranslator : ITagTranslator
    {
        public string ToString(Tag tag)
        {
            if (tag == Tag.Episode)
                throw new InvalidOperationException();
            if (tag == Tag.News)
                return "новость";
            if (tag == Tag.Announce)
                return "анонс";
            if (tag == Tag.Ongoing)
                return "онгоинг";
            if (tag == Tag.Release)
                return "релиз";

            throw new ArgumentException("Недопустимый параметр tag");
        }
        public Tag ToTag(string tag)
        {
            if (tag == "новость")
                return Tag.News;
            if (tag == "анонс")
                return Tag.Announce;
            if (tag == "онгоинг")
                return Tag.Ongoing;
            if (int.TryParse(tag, out var x))
                return Tag.Episode;
            if (tag == "релиз")
                return Tag.Release;

            throw new ArgumentException("Недопустимый параметр tag");
        }
    }
}
