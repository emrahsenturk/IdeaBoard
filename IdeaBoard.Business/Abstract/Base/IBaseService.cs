using System;
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
        IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> predicate, params string[] includes);
        TModel Insert(TModel model);
        TModel Update(TModel model);
        void Delete(TId id);
    }
}
