using LeadManagermentApi.Data.Models.Entity;

namespace LeadManagermentApi.Repositories;

/// <summary>
/// A repsitory that can read and write records of type TEntity.
/// </summary>
public interface IReadWriteRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
    where TEntity : class, IEntity
{
}