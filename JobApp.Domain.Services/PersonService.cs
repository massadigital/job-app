using JobApp.Common.Data;
using JobApp.Domain.Models;
using JobApp.Interfaces.Data.Repositories;
using JobApp.Interfaces.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Domain.Services
{
    public class PersonService : IPersonService
    {
        protected IPersonRepository PersonRepository { get; }
        public PersonService(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }
        public async Task<long> Add(Person instance)
        {
            var result = await PersonRepository.Add(instance);
            return result;
        }

        public async Task<bool> Delete(long id)
        {
            var result = await PersonRepository.Delete(id);
            return result;
        }

        public async Task<Person> Get(long id)
        {
            var result = await PersonRepository.Get(id);
            return result;
        }

        public async Task<DataResult<Person>> Query(DataQuery<Person> query)
        {
            var result = await PersonRepository.Query(query);
            return result;
        }

        public async Task<IQueryable<Person>> Query(Action<IQueryable<Person>> expression)
        {
            var result = await PersonRepository.Query(expression);
            return result;
        }

        public async Task<bool> Update(Person instance)
        {
            var currentInstance = await Get(instance.PersonId);

            MergePerson(currentInstance, instance);

            var result = await PersonRepository.Update(currentInstance);

            return result;
        }

        protected void MergePerson(Person current, Person instance)
        {
            current.PersonName = instance.PersonName;
            current.PersonEmail = instance.PersonName;
        }
    }
}
