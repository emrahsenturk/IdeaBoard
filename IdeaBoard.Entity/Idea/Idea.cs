using IdeaBoard.Entity.Base;
using System;

namespace IdeaBoard.Entity.Idea
{
    public class Idea : BaseEntity
    {
        public Guid SessionId { get; set; }
        public string Description { get; set; }
    }
}
