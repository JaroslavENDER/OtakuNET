using System;

namespace OtakuNET.Web.Services
{
    public class TimestampFormatter : ITimestampFormatter
    {
        public string Format(DateTime timestamp)
        {
            var timespan = DateTime.Now - timestamp;

            if (timespan.TotalMinutes < 1)
                return "Только что";
            if (timespan.TotalHours < 1)
                return $"{timespan.TotalMinutes} минут назад";
            if (timespan.TotalDays < 1)
                return $"{timespan.TotalHours} часов назад";
            if (timespan.TotalDays < 7)
                return $"{timespan.TotalDays} дней назад";
            if (timespan.TotalDays == 7)
                return "Неделю назад";

            return timestamp.ToShortDateString();
        }
    }
}
