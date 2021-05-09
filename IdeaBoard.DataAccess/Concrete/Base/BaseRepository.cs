using IdeaBoard.Core.Enumerations;
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

        public virtual TEntity Insert(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            GetEntity().Update(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual void Delete(TId id)
        {
            var entity = GetEntity().Find(id);
            SoftDelete(entity);
        }

        public void SoftDelete(TEntity entity)
        {
            if (entity is null)
                throw new Exception("Entity is null !!!");

            if (entity.GetType().GetProperty("RowStateId") is null)
                throw new Exception("This method should only be used in entities which have RowStateId property!");

            dynamic entityWh = entity;
            entityWh.RowStateId = (byte)RowStates.Deleted;
            Update((TEntity)entityWh);
        }
    }
}
