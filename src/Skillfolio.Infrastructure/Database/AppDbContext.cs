

using Microsoft.EntityFrameworkCore;
using Skillfolio.Domain.Skills;

namespace Skillfolio.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Skill> Skills { get; set; }
}