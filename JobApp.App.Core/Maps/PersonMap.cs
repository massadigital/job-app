using AutoMapper;
using JobApp.App.Core.Models;
using JobApp.Common.Data;
using JobApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace JobApp.App.Core.Maps
{
    public class PersonMap
    {
        protected static Expression<Func<PersonApp, Person>> ConvertToDomain = src => new Person()
        {
            PersonId = src.Id,
            PersonName = src.Name,
            PersonEmail = src.Email
        };

        protected static Expression<Func<Person, PersonApp>> ConvertToApp = src => new PersonApp()
        {
            Id = src.PersonId,
            Name = src.PersonName,
            Email = src.PersonEmail,
            CreatedAt = src.CreatedAt,
            ModifiedAt = src.ModifiedAt,
            Claims = src.PersonHasClaims.Select(e => new ClaimApp()
            {
                SkillId = e.Claim.ClaimSkillId,
                Skill = new SkillApp()
                {
                    Id = e.Claim.ClaimSkillId,
                    Name = e.Claim.Skill.SkillName
                },
                LevelId = (LevelCodeApp)e.Claim.ClaimLevelId,
                Level = new LevelApp()
                {
                    Id = (LevelCodeApp)e.Claim.ClaimLevelId,
                    Name = e.Claim.Level.LevelName
                }
            })
        };

        protected static Func<DataQuery<PersonApp>, DataQuery<Person>, DataQuery<Person>> ConvertDataQueryToDomain = (src, dest) =>
        {

            var result = new DataQuery<Person>()
            {
                SortExpressions = src.SortExpressions.Select(e =>
                {
                    switch (e.Expression)
                    {
                        case "Id":
                            e.Expression = "PersonId";
                            break;
                        default:
                            break;
                    }
                    return e;
                }).ToList(),
                FilterExpressions = src.FilterExpressions,
                Pagination = src.Pagination
            };
            return result;
        };

        protected static Func<DataQuery<Person>, DataQuery<PersonApp>, DataQuery<PersonApp>> ConvertDataQueryToApp = (src, dest) =>
        {

            var result = new DataQuery<PersonApp>()
            {
                SortExpressions = src.SortExpressions.Select(e =>
                {
                    switch (e.Expression)
                    {
                        case "PersonId":
                            e.Expression = "Id";
                            break;
                        default:
                            break;
                    }
                    return e;
                }).ToList(),
                FilterExpressions = src.FilterExpressions,
                Pagination = src.Pagination
            };
            return result;
        };

        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<PersonApp, Person>().ConvertUsing(ConvertToDomain);

            config.CreateMap<Person, PersonApp>().ConvertUsing(ConvertToApp);

            config.CreateMap<DataQuery<Person>, DataQuery<PersonApp>>().ConvertUsing(ConvertDataQueryToApp);

            config.CreateMap<DataQuery<PersonApp>, DataQuery<Person>>().ConvertUsing(ConvertDataQueryToDomain);

            config.CreateMap<DataResult<Person>, DataResult<PersonApp>>()
                    .ForMember(dest => dest.Query, src => src.MapFrom(e => e.Query))
                    .ForAllOtherMembers(e => e.Ignore());
        }
    }
}
