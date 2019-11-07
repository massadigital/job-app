using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Maps
{
    public class MapConfiguration
    {
        public static IMapper Create()
        {
            var cfg = new MapperConfigurationExpression();

            Configure(cfg);


            var mapperConfig = new MapperConfiguration(cfg);

            var mapper = new Mapper(mapperConfig);

            return mapper;
        }
        public static void  Configure(IMapperConfigurationExpression config)
        {
            PersonMap.Configure(config);
        }
    }
}