﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace IdeaBoard.DataAccess.Abstract.Base
{
    public interface IBaseRepository<TEntity, TId>
        where TEntity : class
    {
        TEntity GetById(TId id);
        IQueryable<TEntity> GetQueryable();
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate);
        TEntity Insert(TEntity entity);
    }
}
