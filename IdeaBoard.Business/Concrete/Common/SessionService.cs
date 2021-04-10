using IdeaBoard.Business.Abstract.Common;
using IdeaBoard.Business.Concrete.Base;
using IdeaBoard.DataAccess.Abstract.Base;
using IdeaBoard.DataAccess.Abstract.Common;
using IdeaBoard.Model.Common;
using System;

namespace IdeaBoard.Business.Concrete.Common
{
    public class SessionService : BaseService<ISessionDal, SessionModel, Guid>, ISessionService
    {
        private readonly ISessionDal sessionDal;

        public SessionService(
            ISessionDal sessionDal) : base(sessionDal)
        {
            this.sessionDal = sessionDal;
        }
    }
}
