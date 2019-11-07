using JobApp.App.Core.Interfaces.Handlers;
using JobApp.App.Core.Models;
using JobApp.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JobApp.App.WebApi.Controllers
{
    public class PersonController : ApiController
    {
        protected readonly IPersonHandler PersonHandler;
        public PersonController(IPersonHandler personHandler)
        {
            PersonHandler = personHandler;
        }
        [HttpGet]
        public async Task<HttpResponseMessage> List(int page, int pageSize, string sort, int sortDirection, string filterData)
        {
            var query = DataQuery<PersonApp>.Create(page, pageSize, sort, sortDirection, filterData);

            var result = await PersonHandler.Query(query);

            var responseBody = result.Value.Items;

            var response = Request.CreateResponse(HttpStatusCode.OK, responseBody);

            Helpers.DataResultHelper.GetHeaders(result.Value.Query).ToList().ForEach(e => response.Headers.Add(e.Key, e.Value));

            return response;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(long id)
        {
            var result = await PersonHandler.Get(id);

            return Ok(result.Value);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Add(PersonApp instance)
        {
            var result = await PersonHandler.Add(instance);

            var resultModel = await PersonHandler.Get(result.Value);

            return CreatedAtRoute("Default", new { controller = "Person", action = "Get", id = result.Value }, resultModel.Value);
        }
    }
}
