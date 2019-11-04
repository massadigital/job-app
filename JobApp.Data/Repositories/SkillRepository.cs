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
    public class SkillRepository : Repository<Skill, long>, ISkillRepository
    {
        public SkillRepository(JobAppContext context) : base(context)
        {
        }
        public override long GetKey(Skill instance)
        {
            return instance.SkillId;
        }
    }
}
