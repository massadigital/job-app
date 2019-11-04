using JobApp.App.Core.Interfaces.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JobApp.App.WebApi.Controllers
{
    public class LinqChallengeController : ApiController
    {
        protected readonly ILinqChallengeHandler LinqChallengeHandler;
        public LinqChallengeController(ILinqChallengeHandler linqChallengeHandler)
        {
            LinqChallengeHandler = linqChallengeHandler;
        }
        [HttpGet]
        public IHttpActionResult CollatzTopRanked()
        {
            var result = LinqChallengeHandler.CollatzTopRanked(1, 1000000);

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult EvenOddSplit()
        {
            var itemArray = new int[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            var result = LinqChallengeHandler.EvenOddSplit(itemArray);

            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult NotContainsFilter()
        {
            var list = new int[] { 1, 3, 7, 29, 42, 98, 234, 93 };

            var filterList = new int[] { 4, 6, 93, 7, 55, 32, 3 };

            var result = LinqChallengeHandler.NotContainsFilter(list, filterList);

            return Ok(result);
        }
    }
}
