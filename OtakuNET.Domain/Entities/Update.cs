﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class Update : EntityBase
    {
        public int AnimeId { get; set; }
        public string Tag { get; set; }

        public Anime Anime { get; set; }

        public List<DataListInformation> Information { get; set; } = new List<DataListInformation>();
    }
}
