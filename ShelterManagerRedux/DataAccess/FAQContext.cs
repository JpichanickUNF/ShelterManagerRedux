using ShelterManagerRedux.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShelterManagerRedux.DataAccess
{
    public class FAQContext : DbContext
    {
        public FAQContext() : base("FAQContext")
        {
        }
        public FAQContext(string connString) : base("FAQContext")
        {
            this.Database.Connection.ConnectionString = connString;
        }

        public DbSet<FrequentlyAskedQuestions> FrequentlyAskedQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
