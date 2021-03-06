﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class News
    {
        [Key] public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public DateTime Timestamp { get; set; }
        [Required, MaxLength(10)] public string Tag { get; set; }
        public string ImageSrc { get; set; }
        [Required] public string Text { get; set; }

        public List<Comment> Comments { get; set; }

        public News()
            => Comments = new List<Comment>();
    }
}
