﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace IdeaBoard.Business.Abstract.Base
{
    public interface IBaseService<TModel, TId>
        where TModel : class
    {
        TModel GetById(TId id);
        IQueryable<TModel> GetQueryable();
        IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> predicate);
        TModel Insert(TModel model);
    }
}
