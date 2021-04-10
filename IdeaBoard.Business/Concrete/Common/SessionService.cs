using IdeaBoard.Business.Abstract.Common;
using IdeaBoard.Business.Concrete.Base;
using IdeaBoard.DataAccess.Abstract.Base;
using IdeaBoard.Model.Common;
using System;

namespace IdeaBoard.Business.Concrete.Common
{
    public class SessionService : BaseService<SessionModel, Guid>, ISessionService
    {
        private readonly IBaseRepository<SessionModel, Guid> repository;

        public SessionService(
            IBaseRepository<SessionModel, Guid> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
