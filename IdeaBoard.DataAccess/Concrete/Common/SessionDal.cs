using IdeaBoard.DataAccess.Abstract.Common;
using IdeaBoard.DataAccess.Concrete.Base;
using IdeaBoard.DataAccess.Context;
using IdeaBoard.Model.Common;
using System;

namespace IdeaBoard.DataAccess.Concrete.Common
{
    public class SessionDal : BaseRepository<SessionModel, Guid>, ISessionDal
    {
        public SessionDal(IdeaBoardDbContext context) : base(context)
        {
        }
    }
}
