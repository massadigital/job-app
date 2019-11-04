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
    public class LevelRepository : Repository<Level, LevelCode>, ILevelRepository
    {
        public LevelRepository(JobAppContext context) : base(context)
        {
        }
        public override LevelCode GetKey(Level instance)
        {
            return instance.LevelId;
        }
    }
}
