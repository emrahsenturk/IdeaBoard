using IdeaBoard.Business.Abstract.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdeaBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionService sessionService;

        public HomeController(
            ILogger<HomeController> logger,
            ISessionService sessionService)
        {
            _logger = logger;
            this.sessionService = sessionService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
