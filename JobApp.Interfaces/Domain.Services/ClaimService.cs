using JobApp.Common.Data;
using JobApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.Interfaces.Domain.Services
{
    public interface IClaimService
    {
        Task<IQueryable<Job>> Query(Action<IQueryable<Job>> expression);
    }
}
