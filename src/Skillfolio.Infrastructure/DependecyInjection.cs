using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skillfolio.Domain.LearnedSkills;
using Skillfolio.Domain.Skills;
using Skillfolio.Infrastructure.Database;
using Skillfolio.Infrastructure.Interfaces;
using Skillfolio.Infrastructure.Repositories;

namespace Skillfolio.Infrastructure;

public static class DependencyInjection
{
    public static void AddDb(this IServiceCollection services, string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Skill>, SkillRepository>();
        services.AddScoped<IRepository<LearnedSkill>, LearnedSkillRepository>();
    }
}