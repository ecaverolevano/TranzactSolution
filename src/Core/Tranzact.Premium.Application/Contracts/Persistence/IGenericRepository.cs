using Tranzact.Premium.Domain.Common;

namespace Tranzact.Premium.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseAuditableEntity
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
