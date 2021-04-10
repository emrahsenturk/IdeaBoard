using IdeaBoard.Business.Abstract.Base;
using IdeaBoard.Model.Common;
using System;

namespace IdeaBoard.Business.Abstract.Common
{
    public interface ISessionService : IBaseService<SessionModel, Guid>
    {
    }
}
