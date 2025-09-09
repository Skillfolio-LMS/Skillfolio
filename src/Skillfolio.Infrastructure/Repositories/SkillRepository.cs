using Microsoft.EntityFrameworkCore;
using Skillfolio.Domain.Skills;
using Skillfolio.Infrastructure.Database;
using Skillfolio.Infrastructure.Interfaces;

namespace Skillfolio.Infrastructure.Repositories;

public class SkillRepository(AppDbContext context) : IRepository<Skill>
{
    public async Task<List<Skill>> GetAllAsync(CancellationToken cancellationToken)
    {
        var skills =  await context.Skills.ToListAsync(cancellationToken);
        return skills;
    }
}