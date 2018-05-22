using System;
using System.Linq;
using LA.Domain;

namespace LA.Services
{
    public class NumberProviderMock : INumberProvider
    {
        public Drawing[] GetNumbers(DateRange dateRange)
        {
            var now = DateTime.Now;
            return Enumerable.Range(1, 12).Select(x => new Drawing(new DateTime(now.Year, x, now.Day), new[] { 1, 2, 3, 4, 5, 6 }, x)).ToArray();
        }
    }
}
