using Microsoft.EntityFrameworkCore;

namespace ShelterManagerRedux.DataAccess
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }

        public DbSet<User> Manager { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Managers");


            base.OnModelCreating(modelBuilder);
        }
    }
}
