using System;
using System.Net.Http;
using Xunit;

namespace LA.ConsoleClient.Tests.Uit
{
    public class UnitTest1
    {
        private IRepository sut;

        public UnitTest1()
        {
            var httpClient = new HttpClient();
            this.sut = new Repository(httpClient);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
