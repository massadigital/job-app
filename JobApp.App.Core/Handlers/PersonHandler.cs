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
        protected IMapper<PersonApp, Person> PersonAppMap { get; }
        protected IMapper<Person, PersonApp> PersonMap { get; }
        protected IMapper<DataQuery<Person>, DataQuery<PersonApp>> PersonDataQueryMap { get; }
        protected IMapper<DataQuery<PersonApp>, DataQuery<Person>> PersonAppDataQueryMap { get; }
        protected IMapper<DataResult<Person>, DataResult<PersonApp>> PersonDataResultMap { get; }
        public PersonHandler(
                IPersonService personService,
                IMapper<PersonApp, Person> personAppMap,
                IMapper<Person, PersonApp> personMap,
                IMapper<DataQuery<PersonApp>, DataQuery<Person>> personAppDataQueryMap,
                IMapper<DataQuery<Person>, DataQuery<PersonApp>> personDataQueryMap,
                IMapper<DataResult<Person>, DataResult<PersonApp>> personDataResultMap)
        {
            PersonService = personService;
            PersonAppMap = personAppMap;
            PersonMap = personMap;
            PersonAppDataQueryMap = personAppDataQueryMap;
            PersonDataQueryMap = personDataQueryMap;
            PersonDataResultMap = personDataResultMap;
        }

        public async Task<BusinessResult<long>> Add(PersonApp instance)
        {
            var domainModel = PersonAppMap.Map(instance);

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

            var resultValue = PersonMap.Map(domainResult);

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
            var domainQuery = PersonAppDataQueryMap.Map(query);
            var domainResult = await PersonService.Query(domainQuery);
            var resultModel = PersonDataResultMap.Map(domainResult);
            var result = new BusinessResult<DataResult<PersonApp>>()
            {
                Success = resultModel != null,
                Value = resultModel
            };

            return result;
        }
    }
}
