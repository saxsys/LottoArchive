using System;
using System.Linq;
using LA.Domain;

namespace LA.Services
{
    public class NumberProviderMock : INumberProvider
    {
        public WinningNumbers[] GetNumbers(DateRange dateRange)
        {
            var now = DateTime.Now;
            return Enumerable.Range(1, 12).Select(x => new WinningNumbers()
            {
                DateTime = new DateTime(now.Year, x, now.Day),
                Numbers = new[]{1,2,3,4,5,6}
            }).ToArray();
        }
    }
}
