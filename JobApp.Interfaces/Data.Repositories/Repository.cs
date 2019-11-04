using JobApp.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Interfaces.Data.Repositories
{
    public interface IRepository<T, TKey> where T : class, new()
    {
        TKey GetKey(T instance);
        Task<TKey> Add(T instance);
        Task<T> Get(TKey id);
        Task<bool> Update(T instance);
        Task<bool> Delete(TKey id);
        Task<bool> Destroy(TKey id);
        Task<DataResult<T>> Query(DataQuery<T> query);
        Task<IQueryable<T>> Query(Action<IQueryable<T>> expression);
    }
}
