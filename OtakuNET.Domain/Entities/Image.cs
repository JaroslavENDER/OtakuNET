using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class Image : EntityBase
    {
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
    }
}
