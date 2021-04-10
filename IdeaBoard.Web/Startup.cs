using IdeaBoard.Business.Abstract.Common;
using IdeaBoard.Business.Abstract.Idea;
using IdeaBoard.Business.Concrete.Common;
using IdeaBoard.Business.Concrete.Idea;
using IdeaBoard.DataAccess.Abstract.Base;
using IdeaBoard.DataAccess.Abstract.Common;
using IdeaBoard.DataAccess.Abstract.Idea;
using IdeaBoard.DataAccess.Concrete.Base;
using IdeaBoard.DataAccess.Concrete.Common;
using IdeaBoard.DataAccess.Concrete.Idea;
using IdeaBoard.DataAccess.Context;
using IdeaBoard.Model.Common;
using IdeaBoard.Model.Idea;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaBoard.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            InjectDataAccess(services);
            InjectBusinessServices(services);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<IdeaBoardDbContext>(opts =>
                opts.UseSqlServer(Configuration["ConnectionStrings:IdeaBoard"]));
        }

        private void InjectDataAccess(IServiceCollection services)
        {
            #region Common
            services.AddScoped<ISessionDal, SessionDal>();
            #endregion

            #region Idea
            services.AddScoped<IIdeaDal, IdeaDal>();
            #endregion
        }

        private void InjectBusinessServices(IServiceCollection services)
        {
            #region Common
            services.AddScoped<ISessionService, SessionService>();
            #endregion

            #region Idea
            services.AddScoped<IIdeaService, IdeaService>();
            #endregion
        }
    }
}
