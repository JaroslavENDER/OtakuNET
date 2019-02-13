using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class News : EntityBase
    {
        public string Title { get; set; }
        public string Tag { get; set; }
        public string ImageSrc { get; set; }
        public string Text { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
