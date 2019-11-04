using JobApp.App.Core.Interfaces.Handlers;
using JobApp.App.Core.Models;
using JobApp.Common.Business;

using JobApp.Interfaces.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Handlers
{
    public class LevelHandler : ILevelHandler
    {
        protected ILevelService LevelService { get; }
        public LevelHandler(ILevelService levelService)
        {
            LevelService = levelService;
        }

        public async Task<BusinessResult<IEnumerable<LevelApp>>> GetAll()
        {
            var domainResult = await LevelService.GetAll();

            var result = new BusinessResult<IEnumerable<LevelApp>>()
            {
                Success = true,
                Value = domainResult.Select(e => new LevelApp() { Id = (LevelCodeApp)e.LevelId, Name = e.LevelName })
            };

            return result;
        }
    }
}
