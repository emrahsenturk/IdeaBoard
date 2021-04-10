using IdeaBoard.Business.Abstract.Base;
using IdeaBoard.Model.Idea;
using System;

namespace IdeaBoard.Business.Abstract.Idea
{
    public interface IIdeaService : IBaseService<IdeaModel, Guid>
    {
    }
}
