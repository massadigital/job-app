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
    public class PersonHasClaimRepository : Repository<PersonHasClaim, object>, IPersonHasClaimRepository
    {
        public PersonHasClaimRepository(JobAppContext context) : base(context)
        {
        }
        public override object GetKey(PersonHasClaim instance)
        {
            return new { instance.PersonClaimId, instance.ClaimPersonId, instance.PersonHasClaimSince };
        }
    }
}
