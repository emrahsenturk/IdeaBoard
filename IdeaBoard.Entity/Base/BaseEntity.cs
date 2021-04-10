using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBoard.Entity.Base
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public byte RowStateId { get; set; }
    }
}
