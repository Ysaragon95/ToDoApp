using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities.Business;
using ToDo.Domain.Entities.Security;

namespace ToDo.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        #region DBSET
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
