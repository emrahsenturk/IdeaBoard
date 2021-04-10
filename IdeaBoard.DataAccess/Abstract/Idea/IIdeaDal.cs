using IdeaBoard.DataAccess.Abstract.Base;
using IdeaBoard.Model.Idea;
using System;

namespace IdeaBoard.DataAccess.Abstract.Idea
{
    public interface IIdeaDal : IBaseRepository<IdeaModel, Guid>
    {
    }
}
