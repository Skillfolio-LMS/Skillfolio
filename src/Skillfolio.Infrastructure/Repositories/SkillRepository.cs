using Microsoft.EntityFrameworkCore;
using Skillfolio.Domain.Skills;
using Skillfolio.Infrastructure.Database;
using Skillfolio.Infrastructure.Interfaces;

namespace Skillfolio.Infrastructure.Repositories;

public class SkillRepository(AppDbContext context) : IRepository<Skill>
{
    public async Task<List<Skill>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Skills.ToListAsync(cancellationToken);
    }

    public async Task<bool> IsExistAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Skills.AnyAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task<Skill> AddAsync(Skill entity, CancellationToken cancellationToken)
    {
        var entry = await context.Skills.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entry.Entity;
    }
}