using IdeaBoard.Business.Abstract.Base;
using IdeaBoard.DataAccess.Abstract.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IdeaBoard.Business.Concrete.Base
{
    public class BaseService<Tdal, TModel, TId> : IBaseService<TModel, TId>
        where TModel : class
        where Tdal : IBaseRepository<TModel, TId>
    {
        protected readonly Tdal dal;

        public BaseService(Tdal dal)
        {
            this.dal = dal;
        }

        public TModel GetById(TId id)
        {
            return dal.GetById(id);
        }

        public IQueryable<TModel> GetQueryable()
        {
            return dal.GetQueryable();
        }

        public IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> predicate)
        {
            return dal.GetQueryable(predicate);
        }

        public IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> predicate, params string[] includes)
        {
            if (includes == null)
                throw new ArgumentNullException("includes", "Value cannot be null");

            return dal.GetQueryable(predicate, includes);
        }

        public TModel Insert(TModel model)
        {
            return dal.Insert(model);
        }

        public TModel Update(TModel model)
        {
            return dal.Update(model);
        }

        public void Delete(TId id)
        {
            dal.Delete(id);
        }
    }
}
