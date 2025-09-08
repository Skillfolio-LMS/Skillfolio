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
        
        builder.Services.AddDb(
            builder.Configuration.GetConnectionString("dbString")!);
    }
}