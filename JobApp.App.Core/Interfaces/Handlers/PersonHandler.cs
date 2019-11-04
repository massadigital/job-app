using JobApp.App.Core.Models;
using JobApp.Common.Business;
using JobApp.Common.Data;
using JobApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Interfaces.Handlers
{
    public interface IPersonHandler
    {
        Task<BusinessResult<long>> Add(PersonApp instance);
        Task<BusinessResult<PersonApp>> Get(long id);
        Task<bool> Update(PersonApp instance);
        Task<bool> Delete(long id);
        Task<BusinessResult<DataResult<PersonApp>>> Query(DataQuery<PersonApp> query);
    }
}
