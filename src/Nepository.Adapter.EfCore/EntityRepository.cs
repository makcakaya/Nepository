using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nepository.EfCore
{
    public sealed class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public EntityRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Delete(params object[] keys)
        {
            _context.Set<TEntity>().Remove(_context.Set<TEntity>().Find(keys));
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public TEntity Get(params object[] keys)
        {
            return _context.Set<TEntity>().Find(keys);
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate = null)
        {
            return predicate is null ? _context.Set<TEntity>().ToArray()
                : _context.Set<TEntity>().Where(predicate);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}