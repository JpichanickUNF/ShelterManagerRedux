using ShelterManagerRedux.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShelterManagerRedux.DataAccess
{
    public class ClientContext : DbContext
    {
        public ClientContext() : base("ClientContext")
        {
        }
        public ClientContext(string connString) : base("ClientContext")
        {
            this.Database.Connection.ConnectionString = connString;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ShelterLocation> ShelterLocations { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
