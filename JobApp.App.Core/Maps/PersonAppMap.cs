using JobApp.App.Core.Models;
using JobApp.Common.Data;
using JobApp.Domain.Models;
using SimpleMapper.Core;
using SimpleMapper.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Maps
{
    public sealed class PersonAppMap : IMapper<PersonApp, Person>
    {
        public Person Map(PersonApp source)
        {
            var result = new Person()
            {
                PersonId = source.Id,
                PersonName = source.Name,
                PersonEmail = source.Email
            };
            return result;
        }
    }
    public sealed class PersonMap : IMapper<Person, PersonApp>
    {
        public PersonApp Map(Person source)
        {
            var result = new PersonApp()
            {
                Id = source.PersonId,
                Name = source.PersonName,
                Email = source.PersonEmail
            };
            return result;
        }
    }
    public sealed class PersonDataQueryMap : IMapper<DataQuery<Person>, DataQuery<PersonApp>>
    {
        public DataQuery<PersonApp> Map(DataQuery<Person> source)
        {
            var result = new DataQuery<PersonApp>()
            {
                SortExpressions = source.SortExpressions,
                FilterExpressions = source.FilterExpressions,
                Pagination = source.Pagination
            };
            return result;
        }
    }
    public sealed class PersonAppDataQueryMap : IMapper<DataQuery<PersonApp>, DataQuery<Person>>
    {
        public DataQuery<Person> Map(DataQuery<PersonApp> source)
        {
            var result = new DataQuery<Person>()
            {
                SortExpressions = source.SortExpressions,
                FilterExpressions = source.FilterExpressions,
                Pagination = source.Pagination
            };
            return result;
        }
    }
    public sealed class PersonDataResultMap : IMapper<DataResult<Person>, DataResult<PersonApp>>
    {
        public DataResult<PersonApp> Map(DataResult<Person> source)
        {
            var result = new DataResult<PersonApp>()
            {
                SortExpressions = source.SortExpressions,
                FilterExpressions = source.FilterExpressions,
                Pagination = source.Pagination,
                //Items = source.Items.Project().To<PersonApp>()
                Items = source.Items.Select(src => new PersonApp()
                {
                    Id = src.PersonId,
                    Name = src.PersonName,
                    Email = src.PersonEmail,
                    CreatedAt = src.CreatedAt,
                    ModifiedAt = src.ModifiedAt
                })
            };
            return result;
        }
    }
}
