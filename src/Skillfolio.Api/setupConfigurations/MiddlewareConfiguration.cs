
using Microsoft.EntityFrameworkCore;
using Skillfolio.Infrastructure.Database;

namespace Skillfolio.Api.setupConfigurations;

public static class MiddlewareConfiguration
{
    public static void ConfigureMiddleWare(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseExceptionMiddleWare();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        
        // Database migration and seeding
        app.ConfigureDb();
        app.SeedSkillsData();
    }

    private static void UseExceptionMiddleWare(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync(ex.Message);
            }
        });
    }

    private static void ConfigureDb(this WebApplication app)
    {
        if (app.Environment.EnvironmentName != "IntegrationTests")
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}