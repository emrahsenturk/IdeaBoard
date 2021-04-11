using AutoMapper;
using IdeaBoard.Model.Common;
using IdeaBoard.Model.Idea;
using IdeaBoard.Web.Models.Common;
using IdeaBoard.Web.Models.Idea;

namespace IdeaBoard.Web.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Common
            CreateMap<SessionModel, SessionViewModel>().ReverseMap();
            #endregion

            #region Idea
            CreateMap<IdeaModel, IdeaViewModel>().ReverseMap();
            #endregion
        }
    }
}
