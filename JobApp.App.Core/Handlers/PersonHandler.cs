using AutoMapper;
using JobApp.App.Core.Interfaces.Handlers;
using JobApp.App.Core.Models;
using JobApp.Common.Business;
using JobApp.Common.Data;
using JobApp.Domain.Models;
using JobApp.Interfaces.Domain.Services;
using SimpleMapper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Handlers
{
    public class PersonHandler : IPersonHandler
    {
        protected IPersonService PersonService { get; }
        protected IMapper Mapper { get; }
        public PersonHandler(
                 IPersonService personService,
                 IMapper mapper)
        {
            PersonService = personService;
            Mapper = mapper;
        }

        public async Task<BusinessResult<long>> Add(PersonApp instance)
        {
            var domainModel = Mapper.Map<Person>(instance);

            var domainResult = await PersonService.Add(domainModel);

            var result = new BusinessResult<long>()
            {
                Success = domainResult > 0,
                Value = domainResult

            };
            return result;
        }

        public async Task<BusinessResult<PersonApp>> Get(long id)
        {

            var domainResult = await PersonService.Get(id);

            var resultValue = Mapper.Map<PersonApp>(domainResult);

            var result = new BusinessResult<PersonApp>()
            {
                Success = resultValue != null,
                Value = resultValue
            };
            return result;
        }

        public Task<bool> Update(PersonApp instance)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<BusinessResult<DataResult<PersonApp>>> Query(DataQuery<PersonApp> query)
        {
            if (!query.SortExpressions.Any())
            {
                query.SortExpressions.Add(new SortExpression("Id"));
            }

            var domainQuery = Mapper.Map<DataQuery<Person>>(query);

            var domainResult = await PersonService.Query(domainQuery);

            var resultModel = Mapper.Map<DataResult<PersonApp>>(domainResult);

            resultModel.Items = domainResult.Items.ProjectToQueryable<PersonApp>(Mapper.ConfigurationProvider);

            var result = new BusinessResult<DataResult<PersonApp>>()
            {
                Success = resultModel != null,
                Value = resultModel
            };


            return result;
        }
    }
}
