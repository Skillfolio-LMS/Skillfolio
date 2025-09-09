using Microsoft.EntityFrameworkCore;
using Skillfolio.Domain.Skills;

namespace Skillfolio.Infrastructure.Interfaces;


public interface IRepository<T> where T : class
{
    Task<List<Skill>> GetAllAsync(CancellationToken cancellationToken);
}