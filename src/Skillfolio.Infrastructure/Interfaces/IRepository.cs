using Skillfolio.Domain.Skills;

namespace Skillfolio.Infrastructure.Interfaces;


public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> IsExistAsync(int id, CancellationToken cancellationToken);
    
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
}