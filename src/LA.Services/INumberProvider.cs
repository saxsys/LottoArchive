using LA.Domain;

namespace LA.Services
{
    public interface INumberProvider
    {
        WinningNumbers[] GetNumbers(DateRange dateRange);
    }
}
