using ShelterManagerRedux.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ShelterManagerRedux.DataAccess
{
    public class ManagerContext : DbContext
    {

        public ManagerContext() : base("ManagerContext")
        {
        }
        public ManagerContext(string connString) : base("ManagerContext")
        {
            this.Database.Connection.ConnectionString = connString;
        }

        public DbSet<Manager> Managers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public Manager AuthenticateManager(string username, string password)
        {
            // Assuming you have a Manager DbSet named "Managers"
            // Replace "Managers" with the actual DbSet name if different
            Manager authenticatedManager = Managers.FirstOrDefault(m => m.Username == username && m.Password == password);

            return authenticatedManager;
        }

        /*
        public ManagerContext(string connString) : base(GetOptions(connString))
        {
        }

        private static DbContextOptions GetOptions(string connString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ManagerContext>();
            optionsBuilder.UseSqlServer(connString);

            return optionsBuilder.Options;
        }
        
        public DbSet<Manager> Managers { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Manager>().ToTable("ManagerAccount");


             base.OnModelCreating(modelBuilder);
         }
        */
    }
}


