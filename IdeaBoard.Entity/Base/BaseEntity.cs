using System;

namespace IdeaBoard.Entity.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public byte RowStateId { get; set; }
    }
}
