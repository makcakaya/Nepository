using System;
using System.Collections.Generic;

namespace Nepository
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Delete(params object[] keys);

        void Update(TEntity entity);

        TEntity Get(params object[] keys);

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate = null);

        void SaveChanges();
    }
}