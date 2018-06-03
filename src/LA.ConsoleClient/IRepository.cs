using System.Threading.Tasks;
using LA.Domain;

namespace LA.ConsoleClient
{
    public interface IRepository
    {
        Task<Drawing[]> Values(DateRange dateRange);
    }
}