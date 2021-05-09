using IdeaBoard.Core.Enumerations;
using IdeaBoard.Entity.Base;
using IdeaBoard.Model.Common;
using IdeaBoard.Model.Idea;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaBoard.DataAccess.Context
{
    public class IdeaBoardDbContext : DbContext
    {
        #region Common
        public DbSet<SessionModel> Sessions { get; set; }
        #endregion

        #region Idea
        public DbSet<IdeaModel> Ideas { get; set; }
        #endregion

        private readonly IHttpContextAccessor httpContextAccessor;

        public IdeaBoardDbContext(
            DbContextOptions options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdeaModel>().HasQueryFilter(p => p.RowStateId != (byte)RowStates.Deleted);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();

            var now = DateTime.Now;

            //var identityUserId = httpContextAccessor.HttpContext?.User?.Claims.Where(p => p.Type.Equals("name")).Select(p => p.Value).FirstOrDefault();
            var CreatedByUserId = Guid.Parse("AAAAAAAA-0000-0000-0000-000000000000");

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedByUserId = CreatedByUserId;
                        entity.CreatedTime = now;
                        entity.RowStateId = (byte)RowStates.New;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        if (entity.RowStateId == (byte)RowStates.Deleted)
                        {
                            entity.RowStateId = (byte)RowStates.Deleted;
                        }
                        else
                        {
                            entity.RowStateId = (byte)RowStates.Updated;
                        }
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
