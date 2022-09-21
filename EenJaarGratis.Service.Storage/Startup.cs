using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EenJaarGratis.Service.Storage;

public static class Startup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Context>(options => options.UseSqlite(configuration.GetConnectionString("default")));
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuestionGroupRepository, QuestionGroupRepository>();
        return services;
    }
}