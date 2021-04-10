using IdeaBoard.DataAccess.Abstract.Idea;
using IdeaBoard.DataAccess.Concrete.Base;
using IdeaBoard.DataAccess.Context;
using IdeaBoard.Model.Idea;
using System;

namespace IdeaBoard.DataAccess.Concrete.Idea
{
    public class IdeaDal : BaseRepository<IdeaModel, Guid>, IIdeaDal
    {
        public IdeaDal(IdeaBoardDbContext context) : base(context)
        {
        }
    }
}
