using IdeaBoard.Entity.Common;
using IdeaBoard.Model.Idea;
using System.Collections.Generic;

namespace IdeaBoard.Model.Common
{
    public class SessionModel : Session
    {
        public SessionModel()
        {
            Ideas = new HashSet<IdeaModel>();
        }

        public virtual ICollection<IdeaModel> Ideas { get; set; }
    }
}
