using JobApp.App.Core.Models;
using JobApp.Common.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Interfaces.Handlers
{
    public interface ILevelHandler
    {
        Task<BusinessResult<IEnumerable<LevelApp>>> GetAll();
    }
}
