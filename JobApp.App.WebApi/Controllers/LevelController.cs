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
    public class LevelController : ApiController
    {
        protected readonly ILevelHandler LevelHandler;
        public LevelController(ILevelHandler levelHandler)
        {
            LevelHandler = levelHandler;
        }
        [HttpGet]
        public async Task<IHttpActionResult> List()
        {
            var result = await LevelHandler.GetAll();

            return Ok(result.Value);
        }
    }
}
