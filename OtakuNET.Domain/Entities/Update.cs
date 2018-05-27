using System.Collections.Generic;

namespace OtakuNET.Domain.Entities
{
    public class Update : NewsBase
    {
        public List<DataListInfomation> Infomation { get; set; }

        public Update()
            => Infomation = new List<DataListInfomation>();
    }
}
