using ShelterManagerRedux.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShelterManagerRedux.DataAccess
{
    public class ClientViewContext : DbContext
    {

        public ClientViewContext(string connString) : base("ClientViewContext")
        {
            this.Database.Connection.ConnectionString = connString;
        }

        public DbSet<ClientView> ClientView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}
