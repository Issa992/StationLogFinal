using System.Collections.Generic;
using System.Threading.Tasks;
using StationLogFinal.Model;

namespace StationLogFinal.Persistency
{
    public interface IWebAPIAsync<T>
    {
        Task<List<T>> Load();
        Task Create(T obj);
        Task<T> Read(int key);
        Task Update(int key, T obj);
        Task Delete(int key);
    }
}
