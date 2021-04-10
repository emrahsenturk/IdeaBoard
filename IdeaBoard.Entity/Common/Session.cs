using IdeaBoard.Entity.Base;
using System;

namespace IdeaBoard.Entity.Common
{
    public class Session : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
