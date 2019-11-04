using JobApp.App.Core.ViewModels;
using JobApp.Common.Business;
using JobApp.Interfaces.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Interfaces.Handlers
{
    public interface ILinqChallengeHandler
    {
        BusinessResult<CollatzTopRankedViewModel> CollatzTopRanked(int min, int max);
        BusinessResult<EvenOddSplitViewModel> EvenOddSplit(int[] itemArray);
        BusinessResult<NotContainsFilterViewModel> NotContainsFilter(int[] list, int[] filterList);
    }
}
