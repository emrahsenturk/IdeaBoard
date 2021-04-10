using IdeaBoard.Business.Abstract.Base;
using IdeaBoard.DataAccess.Abstract.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IdeaBoard.Business.Concrete.Base
{
    public class BaseService<TModel, TId> : IBaseService<TModel, TId>
        where TModel : class
    {
        protected readonly IBaseRepository<TModel, TId> repository;

        public BaseService(IBaseRepository<TModel, TId> repository)
        {
            this.repository = repository;
        }

        public TModel GetById(TId id)
        {
            return repository.GetById(id);
        }

        public IQueryable<TModel> GetQueryable()
        {
            return repository.GetQueryable();
        }

        public IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> predicate)
        {
            return repository.GetQueryable(predicate);
        }

        public TModel Insert(TModel model)
        {
            return repository.Insert(model);
        }
    }
}
