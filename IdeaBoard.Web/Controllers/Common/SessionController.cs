using IdeaBoard.Business.Abstract.Common;
using IdeaBoard.Model.Common;
using IdeaBoard.Web.Controllers.Base;
using IdeaBoard.Web.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace IdeaBoard.Web.Controllers.Common
{
    public class SessionController : BaseController<SessionViewModel, SessionModel>
    {
        private readonly ILogger<SessionController> _logger;
        private readonly ISessionService sessionService;

        public SessionController(
            ILogger<SessionController> logger,
            ISessionService sessionService) : base(sessionService)
        {
            _logger = logger;
            this.sessionService = sessionService;
        }

        public IActionResult Index()
        {
            var activeSessions = sessionService.GetQueryable().ToList();
            return View(ToViewModels(activeSessions));
        }
    }
}
