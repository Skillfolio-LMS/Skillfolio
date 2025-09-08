using Skillfolio.Domain.Skills;
using Skillfolio.Infrastructure.Database;

namespace Skillfolio.Api.setupConfigurations;

public static class SeedData
{
    public static void SeedSkillsData(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            if (!db.Skills.Any())
            {
                db.Skills.AddRange(new Skill("C#", "Programming"), 
                    new Skill("Java", "Programming"), 
                    new Skill("PostgreSQL", "Database"), 
                    new Skill("MsSQL", "Database"), 
                    new Skill("Docker", "DevOps/Tools"), 
                    new Skill("Kubernetes", "DevOps/Tools"), 
                    new Skill("React", "Frameworks"), 
                    new Skill("EF Core", "Frameworks"));

                db.SaveChanges();
            }
        }
    }
}