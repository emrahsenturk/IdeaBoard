using IdeaBoard.Business.Abstract.Idea;
using IdeaBoard.Model.Idea;
using IdeaBoard.Web.Controllers.Base;
using IdeaBoard.Web.Models.Idea;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IdeaBoard.Web.Controllers.Idea
{
    public class IdeaController : BaseController<IdeaViewModel, IdeaModel>
    {
        private readonly IIdeaService ideaService;

        public IdeaController(
            IIdeaService ideaService) : base(ideaService)
        {
            this.ideaService = ideaService;
        }

        public IActionResult Index(Guid sessionId)
        {
            var ideas = ideaService.GetQueryable(q => q.SessionId == sessionId).ToList();
            return View(ToViewModels(ideas));
        }
    }
}
