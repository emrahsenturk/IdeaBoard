using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IdeaBoard.DataAccess.Concrete.Base
{
    public class BaseRepository<TEntity, TId>
        where TEntity : class
    {
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        protected virtual DbSet<TEntity> GetEntity()
        {
            return context.Set<TEntity>();
        }

        public virtual TEntity GetById(TId id)
        {
            return GetEntity().Find(id);
        }

        public virtual IQueryable<TEntity> GetQueryable()
        {
            return GetEntity().AsQueryable();
        }

        public virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return GetEntity().Where(predicate);
        }

        public virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            var queryable = GetEntity().Where(predicate).AsQueryable();
            var result = includes.Aggregate(queryable, (current, inc) => current.Include(inc));
            return result;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public IEnumerable<INavigation> GetNavigations()
        {
            return context.Model.FindEntityType(typeof(TEntity)).GetNavigations();
        }

        public string[] GetNavigationNames()
        {
            return GetNavigations().Select(s => s.Name).ToArray();
        }

        public Expression<Func<TEntity, bool>> FuncToExpression(Func<TEntity, bool> filter)
        {
            return (p) => filter.Invoke(p);
        }
    }
}
