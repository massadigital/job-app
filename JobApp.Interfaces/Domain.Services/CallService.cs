using JobApp.Common.Data;
using JobApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.Interfaces.Domain.Services
{
    public interface ICallService
    {
        Task<long> Add(Call instance);
        Task<Call> Get(long id);
        Task<bool> Update(Call instance);
        Task<bool> Delete(long id);
        Task<DataResult<Call>> Query(DataQuery<Call> query);
        Task<IQueryable<Call>> Query(Action<IQueryable<Call>> expression);
    }
}
