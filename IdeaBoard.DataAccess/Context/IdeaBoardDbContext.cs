using IdeaBoard.Model.Common;
using IdeaBoard.Model.Idea;
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

        public IdeaBoardDbContext(
            DbContextOptions options) : base(options)
        {

        }
    }
}
