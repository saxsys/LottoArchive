using LA.Domain;

namespace LA.Services
{
    public interface IDrawingProvider
    {
        Drawing[] GetNumbers(DateRange dateRange);
    }
}
