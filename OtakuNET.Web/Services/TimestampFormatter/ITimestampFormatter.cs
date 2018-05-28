using System;

namespace OtakuNET.Web.Services
{
    public interface ITimestampFormatter
    {
        string Format(DateTime timestamp);
    }
}
