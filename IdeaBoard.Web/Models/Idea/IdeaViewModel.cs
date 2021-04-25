using IdeaBoard.Web.Models.Common;
using System;

namespace IdeaBoard.Web.Models.Idea
{
    public class IdeaViewModel
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public string Description { get; set; }
        public byte EmojiId { get; set; }

        public SessionViewModel Session { get; set; }
    }
}
