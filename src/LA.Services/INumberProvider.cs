using LA.Domain;

namespace LA.Services
{
    public interface INumberProvider
    {
        Drawing[] GetNumbers(DateRange dateRange);
    }
}
