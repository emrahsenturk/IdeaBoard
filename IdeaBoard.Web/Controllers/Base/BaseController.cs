using AutoMapper;
using IdeaBoard.Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using static IdeaBoard.Web.Startup;

namespace IdeaBoard.Web.Controllers.Base
{
    public class BaseController<TViewModel, TModel> : Controller
        where TViewModel : class, new()
        where TModel : class, new()
    {
        private readonly IBaseService<TModel, Guid> Service;
        protected readonly IMapper mapper;

        public BaseController(IBaseService<TModel, Guid> service)
        {
            Service = service;
            mapper = ServiceProviderFactory.ServiceProvider.GetService<IMapper>();
        }

        [NonAction]
        public virtual TViewModel ToViewModel(TModel model)
        {
            return mapper.Map<TViewModel>(model);
        }

        [NonAction]
        public virtual ICollection<TViewModel> ToViewModels(ICollection<TModel> models)
        {
            return mapper.Map<ICollection<TViewModel>>(models);
        }
    }
}
