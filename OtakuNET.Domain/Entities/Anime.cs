﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Anime : Animanga
    {
        [Required] public AnimeSeason Season { get; set; }
        
        public List<Update> Updates { get; set; }

        public Anime()
            : base()
            => Updates = new List<Update>();
    }
}
