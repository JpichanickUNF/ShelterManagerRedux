using ShelterManagerRedux.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShelterManagerRedux.DataAccess
{
    public class ShelterLocationContext : DbContext
    {
        public ShelterLocationContext() : base("ShelterLocationContext")
        {
        }
        public ShelterLocationContext(string connString) : base("ShelterLocationContext")
        {
            this.Database.Connection.ConnectionString = connString;
        }

      
        public DbSet<ShelterLocation> ShelterLocations { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
