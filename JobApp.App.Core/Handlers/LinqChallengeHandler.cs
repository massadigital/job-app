using JobApp.App.Core.Interfaces.Handlers;
using JobApp.App.Core.ViewModels;
using JobApp.Common.Business;
using JobApp.Interfaces.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Handlers
{
    public class LinqChallengeHandler : ILinqChallengeHandler
    {
        protected ILinqChallengeService LinqChallengeService { get; }
        public LinqChallengeHandler(ILinqChallengeService linqChallengeService)
        {
            LinqChallengeService = linqChallengeService;
        }
        public BusinessResult<CollatzTopRankedViewModel> CollatzTopRanked(int min, int max)
        {
            var resultList = LinqChallengeService.CollatzRanking(min, max);

            var resultModel = new CollatzTopRankedViewModel()
            {
                Min = min,
                Max = max,
                TopRanked = resultList.First()
            };

            var resultMessage = string.Format("A maior sequência gerada aplicando-se o problema de collatz entre {2:###,###,###,##0} e {3:###,###,###,##0} é do número: {0} com {1} itens.\r\n", resultModel.TopRanked[0], resultModel.TopRanked.Length, resultModel.Min, resultModel.Max);
            resultMessage += string.Format("{0}\r\n", string.Join(" - ", resultModel.TopRanked));

            var result = new BusinessResult<CollatzTopRankedViewModel>()
            {
                Success = true,
                Message = resultMessage,
                Value = resultModel
            };
            return result;
        }
        public BusinessResult<EvenOddSplitViewModel> EvenOddSplit(int[] itemArray)
        {
            LinqChallengeService.EvenOddSplit(itemArray, out int[] evens, out int[] odds);
            var resultModel = new EvenOddSplitViewModel()
            {
                Subject = itemArray,
                Evens = evens,
                Odds = odds
            };
            var resultMessage = string.Format("Análise da matriz [{1}] com {0} elementos:\r\n", resultModel.Subject.Length, string.Join(",", resultModel.Subject));
            resultMessage += string.Format("Contém {0} números ímpares: [{1}]\r\n", resultModel.Odds.Length, string.Join(",", resultModel.Odds));
            resultMessage += string.Format("Contém {0} números pares: [{1}]\r\n", resultModel.Evens.Length, string.Join(",", resultModel.Evens));

            var result = new BusinessResult<EvenOddSplitViewModel>()
            {
                Success = true,
                Message = resultMessage,
                Value = resultModel
            };

            return result;
        }
        public BusinessResult<NotContainsFilterViewModel> NotContainsFilter(int[] list, int[] filterList)
        {
            var resultArray = LinqChallengeService.NotContainsFilter(list, filterList);
            var resultModel = new NotContainsFilterViewModel()
            {
                Subject = list,
                Filter = filterList,
                NotContained = resultArray
            };

            var resultMessage = string.Format("Os elementos da matriz [{0}] não contidos em [{1}] são: [{2}]\r\n", string.Join(",", resultModel.Subject), string.Join(",", resultModel.Filter), string.Join(",", resultModel.NotContained));

            var result = new BusinessResult<NotContainsFilterViewModel>()
            {
                Success = true,
                Message = resultMessage,
                Value = resultModel
            };

            return result;
        }
    }
}
