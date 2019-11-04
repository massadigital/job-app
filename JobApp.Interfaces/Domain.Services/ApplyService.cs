using JobApp.Common.Data;
using JobApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.Interfaces.Domain.Services
{
    public interface IApplyService
    {
        Task<long> Add(Apply instance);
        Task<Apply> Get(long id);
        Task<bool> Update(Apply instance);
        Task<bool> Delete(long id);
        Task<DataResult<Apply>> Query(DataQuery<Apply> query);
        Task<IQueryable<Apply>> Query(Action<IQueryable<Apply>> expression);
    }
}
