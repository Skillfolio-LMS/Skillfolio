
using Microsoft.EntityFrameworkCore;
using Skillfolio.Application.Exceptions;
using Skillfolio.Domain.Skills;
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
        
        app.ConfigureDb();
    }

    private static void UseExceptionMiddleWare(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (CustomException exception)
            {
                context.Response.StatusCode = exception.StatusCode;
                await context.Response.WriteAsync(exception.Message);
            }
        });
    }

    private static void ConfigureDb(this WebApplication app)
    {
        if (app.Environment.EnvironmentName == "IntegrationTests") return;
        
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
        
        if (dbContext.Skills.Any()) return;
        
        dbContext.Skills.AddRange(new Skill("C#", "Programming"), 
            new Skill("Java", "Programming"), 
            new Skill("PostgreSQL", "Database"), 
            new Skill("MsSQL", "Database"), 
            new Skill("Docker", "DevOps/Tools"), 
            new Skill("Kubernetes", "DevOps/Tools"), 
            new Skill("React", "Frameworks"), 
            new Skill("EF Core", "Frameworks"));

        dbContext.SaveChanges();
    }
}