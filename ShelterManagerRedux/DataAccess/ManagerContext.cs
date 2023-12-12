using Microsoft.EntityFrameworkCore;

namespace ShelterManagerRedux.DataAccess
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(string connString) : base(GetOptions(connString))
        {
        }

        private static DbContextOptions GetOptions(string connString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ManagerContext>();
            optionsBuilder.UseSqlServer(connString);

            return optionsBuilder.Options;
        }

        public DbSet<Manager> Manager { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().ToTable("Managers");


            base.OnModelCreating(modelBuilder);
        }
    }
}
