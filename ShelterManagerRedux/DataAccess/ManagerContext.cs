using ShelterManagerRedux.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShelterManagerRedux.DataAccess
{
    public class ManagerContext : DbContext
    {

        public ManagerContext(string connString) : base("ManagerContext")
        {
            this.Database.Connection.ConnectionString = connString;
        }

        public DbSet<User> Manager { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}