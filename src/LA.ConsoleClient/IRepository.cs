using System.Collections.Generic;
using System.Threading.Tasks;
using LA.Domain;

namespace LA.ConsoleClient
{
    public interface IRepository
    {
        Task<List<DrawingAttribute>> Values(DateRange dateRange);
    }
}