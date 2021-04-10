using IdeaBoard.DataAccess.Abstract.Base;
using IdeaBoard.Model.Common;
using System;

namespace IdeaBoard.DataAccess.Abstract.Common
{
    public interface ISessionDal : IBaseRepository<SessionModel, Guid>
    {
    }
}
