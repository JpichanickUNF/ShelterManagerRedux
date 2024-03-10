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
            return Managers.FirstOrDefault(m => m.Username == username && m.Password == password);
        }


    }
}


