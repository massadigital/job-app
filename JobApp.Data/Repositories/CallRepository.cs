using JobApp.Data.Contexts;
using JobApp.Domain.Models;
using JobApp.Interfaces.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Data.Repositories
{
    public class CallRepository : Repository<Call, long>, ICallRepository
    {
        public CallRepository(JobAppContext context) : base(context)
        {
        }
        public override long GetKey(Call instance)
        {
            return instance.CallId;
        }
    }
}
