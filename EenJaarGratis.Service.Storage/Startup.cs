using EenJaarGratis.Service.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EenJaarGratis.Service.Storage;

public static class Startup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Context>(options => options.UseInMemoryDatabase(configuration.GetConnectionString("default")));
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        return services;
    }
}