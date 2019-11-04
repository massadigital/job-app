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
    public class JobHasClaimRepository : Repository<JobHasClaim, object>, IJobHasClaimRepository
    {
        public JobHasClaimRepository(JobAppContext context) : base(context)
        {
        }
        public override object GetKey(JobHasClaim instance)
        {
            return new { instance.JobClaimId, instance.ClaimJobId };
        }
    }
}
