using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Update
    {
        [Key] public int Id { get; set; }
        [Required] public DateTime Timestamp { get; set; }
        [Required] public string Tag { get; set; }

        [Required] public Anime Anime { get; set; }

        public List<DataListInfomation> Infomation { get; set; }

        public Update()
            => Infomation = new List<DataListInfomation>();
    }
}
