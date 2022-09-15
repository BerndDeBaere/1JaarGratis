using EenJaarGratis.Services.Handlers.Mapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EenJaarGratis.Services.Handlers;

public static class Startup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        Service.Storage.Startup.RegisterServices(services, configuration);
        services.AddMediatR(typeof(Startup));
        services.AddAutoMapper(config => config.AddProfile(typeof(MapperProfile)));
        return services;
    }
}