using JobApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Interfaces.Data.Repositories
{
    public interface ISkillRepository : IRepository<Skill, long>
    {
    }
}
