using IdeaBoard.Web.Models.Idea;
using System;
using System.Collections.Generic;

namespace IdeaBoard.Web.Models.Common
{
    public class SessionViewModel
    {
        public SessionViewModel()
        {
            Ideas = new HashSet<IdeaViewModel>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<IdeaViewModel> Ideas { get; set; }
    }
}
