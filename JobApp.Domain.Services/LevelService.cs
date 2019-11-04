using JobApp.Domain.Models;
using JobApp.Interfaces.Data.Repositories;
using JobApp.Interfaces.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Domain.Services
{
    public class LevelService : ILevelService
    {
        protected ILevelRepository LevelRepository { get; }
        public LevelService(ILevelRepository levelRepository)
        {
            LevelRepository = levelRepository;
        }

        public async Task<IQueryable<Level>> GetAll()
        {
            var result = await LevelRepository.Query(e=>e.OrderBy(x=>x.LevelId));
            return result;
        }
    }
}
