using AutoMapper;
using Gateway.API.Models;

namespace Gateway.API.IoC
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Service.Grpc.Person, Person>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
