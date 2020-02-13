using AutoMapper;
using AutomapperTest.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomapperTest.MapperFactory
{
    public static class ObjectMapperFactory
    {
        public static IMapper CreateMapper<TSource, TDestination>()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<TSource,TDestination>()
                    .PreserveReferences()
                    .AfterMap((src, dest) =>
                    {
                        ////var type1 = Type.GetType(src.GetType().FullName);
                        ////var type = src.GetType();
                        ////var test = dest.Equals(src);
                        ////var data = Convert.ChangeType(src, type1);
                    });
                    cfg.Advanced.AllowAdditiveTypeMapCreation = true;
                    cfg.AllowNullDestinationValues = true;
                    cfg.AllowNullCollections = true;
                });

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}