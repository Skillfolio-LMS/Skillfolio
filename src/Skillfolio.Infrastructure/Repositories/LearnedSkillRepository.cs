using Microsoft.EntityFrameworkCore;
using Skillfolio.Domain.LearnedSkills;
using Skillfolio.Infrastructure.Database;
using Skillfolio.Infrastructure.Interfaces;

namespace Skillfolio.Infrastructure.Repositories;

public class LearnedSkillRepository(AppDbContext context) : IRepository<LearnedSkill>
{
    public async Task<List<LearnedSkill>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.LearnedSkills
            .Include(ls => ls.Skill)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsExistAsync(int id, CancellationToken cancellationToken)
    {
        return await context.LearnedSkills
            .AnyAsync(ls => ls.Id == id, cancellationToken);
    }
    
    public async Task<LearnedSkill> AddAsync(LearnedSkill entity, CancellationToken cancellationToken)
    {
        var entry = await context.LearnedSkills.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entry.Entity;
    }
}
