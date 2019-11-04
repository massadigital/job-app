using JobApp.Common.Data;
using JobApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.Interfaces.Domain.Services
{
    public interface ISkillService
    {
        Task<long> Add(Skill instance);
        Task<Skill> Get(long id);
        Task<bool> Update(Skill instance);
        Task<bool> Delete(long id);
        Task<DataResult<Skill>> Query(DataQuery<Skill> query);
        Task<IQueryable<Skill>> Query(Action<IQueryable<Skill>> expression);
    }
}
