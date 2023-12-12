using ShelterManagerRedux.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShelterManagerRedux.DataAccess
{
    public class ShelterProfileContext : DbContext
    {
        public ShelterProfileContext(string connString) : base("ShelterProfileContext")
        {
            this.Database.Connection.ConnectionString = connString;
        }

        public DbSet<ShelterProfile> ShelterProfile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
