using JobApp.Common.Data;
using JobApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.Interfaces.Domain.Services
{
    public interface ILevelService
    {
        Task<IQueryable<Level>> GetAll();
    }
}
