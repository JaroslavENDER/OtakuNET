using Ender.TimestampFormatterCore;
using System;
using Xunit;

namespace OtakuNET.Web.Tests.Services
{
    public class TimestampFormatterTest
    {
        private ITimestampFormatter formatter = new TimestampFormatter();

        [Fact]
        public void InMinute()
        {
            var date = DateTime.Now.AddSeconds(-10);

            Assert.Equal("Только что", formatter.Format(date));
        }

        [Fact]
        public void InHours()
        {
            var date = DateTime.Now.AddMinutes(-10);

            Assert.Equal("10 минут назад", formatter.Format(date));
        }

        [Fact]
        public void InDay()
        {
            var date = DateTime.Now.AddHours(-21);

            Assert.Equal("21 час назад", formatter.Format(date));
        }

        [Fact]
        public void In6Days()
        {
            var date = DateTime.Now.AddDays(-3);

            Assert.Equal("3 дня назад", formatter.Format(date));
        }

        [Fact]
        public void In7Day()
        {
            var date = DateTime.Now.AddDays(-7);

            Assert.Equal("Неделю назад", formatter.Format(date));
        }

        [Fact]
        public void InMonthEndMore()
        {
            var date = DateTime.Now.AddDays(-60);

            Assert.Equal(date.ToLongDateString(), formatter.Format(date));
        }
    }
}
