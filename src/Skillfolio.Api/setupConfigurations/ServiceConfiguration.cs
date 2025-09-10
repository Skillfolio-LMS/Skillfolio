using Skillfolio.Application.Skills.Queries;
using Skillfolio.Domain.Skills.Query;
using Skillfolio.Infrastructure;

namespace Skillfolio.Api.setupConfigurations;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors();
        builder.Services.AddRepositories();
        
        builder.Services.RegisterMediatR();

        if (builder.Environment.EnvironmentName != "IntegrationTests")
        {
            builder.Services.AddDb(Environment.GetEnvironmentVariable("dbString")!);
        }
    }
    
    private static void RegisterMediatR(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg => 
                cfg.RegisterServicesFromAssemblies(
                    typeof(Program).Assembly, typeof(GetAllSkillsHandler).Assembly, typeof(GetAllSkills).Assembly)
        );
    }
}