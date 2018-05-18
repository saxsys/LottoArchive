using LA.Domain;

namespace LA.Services
{
    public interface INumberProvider
    {
        int[] GetNumbers(DateRange dateRange);
    }
}
