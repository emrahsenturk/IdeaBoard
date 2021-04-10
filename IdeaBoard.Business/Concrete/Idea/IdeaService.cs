using IdeaBoard.Business.Abstract.Idea;
using IdeaBoard.Business.Concrete.Base;
using IdeaBoard.DataAccess.Abstract.Idea;
using IdeaBoard.Model.Idea;
using System;

namespace IdeaBoard.Business.Concrete.Idea
{
    public class IdeaService : BaseService<IIdeaDal, IdeaModel, Guid>, IIdeaService
    {
        private readonly IIdeaDal ideaDal;

        public IdeaService(
            IIdeaDal ideaDal) : base(ideaDal)
        {
            this.ideaDal = ideaDal;
        }
    }
}
