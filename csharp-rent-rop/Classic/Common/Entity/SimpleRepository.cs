using System;
using System.Collections.Generic;
using System.Linq;

namespace Richargh.BillionDollar.Classic.Common.Entity
{
    public class SimpleRepository<TId, TEntity> 
        where TId : notnull
        where TEntity : IEntity<TId>
    {
        private readonly Dictionary<TId, TEntity> _allEntities;

        public SimpleRepository(IEnumerable<TEntity> entities)
        {
            _allEntities = entities.ToDictionary(it => it.Id);
        }

        public SimpleRepository(params TEntity[] entities) : this(entities.ToList())
        {
        }

        // TEntity? can be written like this only because we use C#9, otherwise TEntity would have to use a class constraint or similar
        public TEntity? FindById(TId id)
        {
            return _allEntities.GetValueOrDefault(id);
        }

        public TEntity? Find(Func<KeyValuePair<TId,TEntity>,bool> predicate)
        {
            var result = _allEntities.FirstOrDefault(predicate);
            return result.Value;
        }

        public void Put(TEntity entity)
        {
            _allEntities[entity.Id] = entity;
        }
    }
}