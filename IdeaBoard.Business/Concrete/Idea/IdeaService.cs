using IdeaBoard.Business.Abstract.Idea;
using IdeaBoard.Business.Concrete.Base;
using IdeaBoard.DataAccess.Abstract.Base;
using IdeaBoard.Model.Idea;
using System;

namespace IdeaBoard.Business.Concrete.Idea
{
    public class IdeaService : BaseService<IdeaModel, Guid>, IIdeaService
    {
        private readonly IBaseRepository<IdeaModel, Guid> repository;

        public IdeaService(
            IBaseRepository<IdeaModel, Guid> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
