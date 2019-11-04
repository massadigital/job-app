using JobApp.Common.Data;
using JobApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.Interfaces.Domain.Services
{
    public interface IJobService
    {
        Task<long> Add(Job instance);
        Task<Job> Get(long id);
        Task<bool> Update(Job instance);
        Task<bool> Delete(long id);
        Task<DataResult<Job>> Query(DataQuery<Job> query);
        Task<IQueryable<Job>> Query(Action<IQueryable<Job>> expression);
    }
}
