using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Controllers
{
    public class CustomController : ControllerBase
    {
        private IMapper Mapper { get; set; }

        public CustomController()
        {

        }

        public TDestination MapTo<TSource, TDestination>(TSource source)
        {
            Mapper = GetMapperConfiguration<TSource, TDestination>();
            return Mapper.Map<TSource, TDestination>(source);
        }

        public List<TDestination> MapListTo<TSource, TDestination>(List<TSource> source)
        {
            Mapper = GetMapperConfiguration<TSource, TDestination>();
            return Mapper.Map<List<TSource>, List<TDestination>>(source);
        }

        /// <summary>
        /// Return the mapper if it's not null, otherwise creates a new one.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns></returns>
        private IMapper GetMapperConfiguration<TSource, TDestination>()
        {
            if (Mapper != null)
                return Mapper;

            var mapperConfiguration = new MapperConfigurationExpression();
            mapperConfiguration.CreateMap<TSource, TDestination>();
            var mapperConfigurationProvider = new MapperConfiguration(mapperConfiguration);
            return mapperConfigurationProvider.CreateMapper();
        }
    }
}
