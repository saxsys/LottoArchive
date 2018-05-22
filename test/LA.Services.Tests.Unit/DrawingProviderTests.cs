// DrawingProviderTests.cs
// 
// Comments : 
// Date     : 2018/05/22
// Author   :  Hendrik Lösch
// <copyright file="DrawingProviderTests.cs" company="Carl Zeiss Microscopy GmbH">
//      Copyright (c) Carl Zeiss Microscopy GmbH. All rights reserved.
// </copyright>

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using LA.Domain;
using LA.Services;
using Xunit;

namespace LA.Services.Tests.Unit
{
    public class DrawingProviderTests
    {
        [Fact]
        public void ProviderReturnsOneDataSetPerLine()
        {
            var stream = PrepareTestData();
            var sut = new DrawingProvider(stream);
            var dataSets = sut.GetNumbers(new DateRange(DateTime.MinValue, DateTime.MaxValue));

            Assert.Equal(4, dataSets.Count());
        }

        [Fact]
        public void ResultDataContainsAValidDate()
        {
            var stream = PrepareTestData();
            var sut = new DrawingProvider(stream);
            var dataSets = sut.GetNumbers(new DateRange(DateTime.MinValue, DateTime.MaxValue));

            var drawing = dataSets.First();
            Assert.Equal(new DateTime(2017, 01, 04), drawing.DateTime);
        }

        [Fact]
        public void ResultDataContainsValidNumbersOrderdAsc()
        {
            var stream = PrepareTestData();
            var sut = new DrawingProvider(stream);
            var dataSets = sut.GetNumbers(new DateRange(DateTime.MinValue, DateTime.MaxValue));

            var drawing = dataSets.First();
            Assert.Equal(new []{5, 13, 21, 37, 39, 48 }, drawing.Numbers);

            drawing = dataSets.Last();
            Assert.Equal(new[] { 3, 4, 23, 27, 28, 37 }, drawing.Numbers);
        }

        [Fact]
        public void ResultContainsCorrectSuperNumber()
        {
            var stream = PrepareTestData();
            var sut = new DrawingProvider(stream);
            var dataSets = sut.GetNumbers(new DateRange(DateTime.MinValue, DateTime.MaxValue));

            var drawing = dataSets.First();
            Assert.Equal(2, drawing.SuperNumber);
        }

        [Fact]
        public void OnlyResultsForAGivenDateRangeAreProvided()
        {
            var stream = PrepareTestData();
            var sut = new DrawingProvider(stream);
            var dataSets = sut.GetNumbers(new DateRange(new DateTime(2017, 01, 04), new DateTime(2017, 01, 07)));

            Assert.Equal(2, dataSets.Length);
        }

        private static MemoryStream PrepareTestData()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("04.01.2017;48;5;39;37;21;13;2");
            stringBuilder.AppendLine("07.01.2017; 22; 12; 14; 45; 17; 46; 1");
            stringBuilder.AppendLine("11.01.2017; 29; 32; 27; 38; 34; 20; 3");
            stringBuilder.AppendLine("14.01.2017; 23; 37; 27; 4; 3; 28; 4");

            var data = Encoding.ASCII.GetBytes(stringBuilder.ToString());

            var memoryStream = new MemoryStream(data);
            return memoryStream;
        }
    }
}