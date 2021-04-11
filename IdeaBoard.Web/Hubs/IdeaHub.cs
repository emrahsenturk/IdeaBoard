using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaBoard.Web.Hubs
{
    public class IdeaHub : Hub
    {
        public async Task SaveIdea(string sessionId, string description)
        {
            //Tüm ideas alınacak burada.
            await Clients.All.SendAsync("UpdateIdeas", sessionId, description);
        }
    }
}
