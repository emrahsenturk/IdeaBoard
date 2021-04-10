using Microsoft.EntityFrameworkCore;
using System;
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

        public virtual TEntity Insert(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
