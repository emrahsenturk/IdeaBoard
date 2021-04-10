using IdeaBoard.Model.Common;

namespace IdeaBoard.Model.Idea
{
    public class IdeaModel : Entity.Idea.Idea
    {
        public virtual SessionModel Session { get; set; }
    }
}
