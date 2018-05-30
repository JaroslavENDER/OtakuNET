using Moq;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OtakuNET.Web.Tests.ModelExtentions.NewsViewModelsExtensions
{
    public class OneUpdateViewModelExtensionsTest
    {
        [Fact]
        public void Transform_DataListInfo_In_ViewModel()
        {
            var tagTranslatorMock = new Mock<ITagTranslator>();
            tagTranslatorMock.Setup(m => m.ToTag(It.IsAny<string>())).Returns<string>(s => Tag.Ongoing);
            var timestampFormatterMock = new Mock<ITimestampFormatter>();
            timestampFormatterMock.Setup(m => m.Format(It.IsAny<DateTime>())).Returns<DateTime>(dt => string.Empty);
            var update = new Update
            {
                Anime = new Anime(),
                Infomation = new List<DataListInfomation>
                {
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "OVA"
                    },
                    new DataListInfomation
                    {
                        Name = "Тип",
                        Value = "Сериал"
                    },
                    new DataListInfomation
                    {
                        Name = "Эпизодов",
                        Value = "12"
                    }
                }
            };

            var result = new OneUpdateViewModel().Initialize(update, tagTranslatorMock.Object, timestampFormatterMock.Object);

            Assert.Equal(2, result.Info.Count);

            Assert.Equal(2, result.Info[0].Values.Count);
            Assert.Equal("Тип", result.Info[0].Key);
            Assert.Equal("OVA", result.Info[0].Values[0]);
            Assert.Equal("Сериал", result.Info[0].Values[1]);

            Assert.Single(result.Info[1].Values);
            Assert.Equal("Эпизодов", result.Info[1].Key);
            Assert.Equal("12", result.Info[1].Values[0]);
        }
    }
}
