using IdeaBoard.Business.Abstract.Common;
using IdeaBoard.Business.Abstract.Idea;
using IdeaBoard.Model.Idea;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaBoard.Web.Hubs
{
    public class IdeaHub : Hub
    {
        private readonly IIdeaService ideaService;
        private readonly ISessionService sessionService;

        public IdeaHub(
            IIdeaService ideaService,
            ISessionService sessionService)
        {
            this.ideaService = ideaService;
            this.sessionService = sessionService;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SaveIdea(string strSessionId, string description, string emojiId)
        {
            var sessionId = Guid.Parse(strSessionId);
            var idea = new IdeaModel
            {
                SessionId = sessionId,
                Description = description,
                EmojiId = Convert.ToByte(emojiId)
            };

            idea = ideaService.Insert(idea);

            await Clients.All.SendAsync("AddNewIdea", sessionId, idea);
        }

        public async Task DeleteIdea(string strIdeaId)
        {
            var ideaId = Guid.Parse(strIdeaId);
            ideaService.Delete(ideaId);

            await Clients.All.SendAsync("RemoveIdea");
        }
    }
}
