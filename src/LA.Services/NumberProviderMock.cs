using LA.Domain;

namespace LA.Services
{
    public class NumberProviderMock : INumberProvider
    {
        public int[] GetNumbers(DateRange dateRange)
            => new[] { 1,2,3,4,5, 6 };
    }
}
