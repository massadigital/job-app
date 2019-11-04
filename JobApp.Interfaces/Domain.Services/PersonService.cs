using JobApp.Common.Data;
using JobApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.Interfaces.Domain.Services
{
    public interface IPersonService
    {
        Task<long> Add(Person instance);
        Task<Person> Get(long id);
        Task<bool> Update(Person instance);
        Task<bool> Delete(long id);
        Task<DataResult<Person>> Query(DataQuery<Person> query);
        Task<IQueryable<Person>> Query(Action<IQueryable<Person>> expression);
    }
}
