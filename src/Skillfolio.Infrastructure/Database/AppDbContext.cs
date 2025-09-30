using Microsoft.EntityFrameworkCore;
using Skillfolio.Domain.LearnedSkills;
using Skillfolio.Domain.Skills;
using Skillfolio.Infrastructure.Database.Configurations;

namespace Skillfolio.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Skill> Skills { get; set; }
    public DbSet<LearnedSkill> LearnedSkills { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkillConfiguration).Assembly);
    }
}