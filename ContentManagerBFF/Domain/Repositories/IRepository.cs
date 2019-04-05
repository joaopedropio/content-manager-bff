using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<IList<T>> List();
        Task<T> FindById(uint id);
        Task Remove(uint id);
        Task Insert(T obj);
    }
}
