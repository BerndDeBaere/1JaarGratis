using EenJaarGratis.Service.Handlers.Mapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EenJaarGratis.Service.Handlers;

public static class Startup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        Storage.Startup.RegisterServices(services, configuration);
        
        services.AddMediatR(typeof(GetPlayersHandler));

        
        services.AddAutoMapper(config => config.AddMaps(typeof(MapperProfile)));
        return services;
    }
}