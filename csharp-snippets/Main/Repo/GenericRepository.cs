using System.Collections.Generic;
using System.Linq;

namespace Richargh.BillionDollar.Repo
{
    public abstract class GenericRepository<TId, TEntity> 
        where TId : notnull
        where TEntity : IEntity<TId>
    {
    private readonly Dictionary<TId, TEntity> _allEntities;

    public GenericRepository(IEnumerable<TEntity> entities)
    {
        _allEntities = entities.ToDictionary(it => it.Id);
    }

    public GenericRepository(params TEntity[] employees) : this(employees.ToList())
    {
    }

    // TEntity? can be written like this only because we use C#9, otherwise TEntity would have to use a class constraint or similar
    public TEntity? FindById(TId id)
    {
        return _allEntities.GetValueOrDefault(id);
    }

    public void Put(TEntity entity)
    {
        _allEntities[entity.Id] = entity;
    }
    }
}