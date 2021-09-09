using CreditCardValidation.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CreditCardValidation.DAL
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext() : base("CreditCardContext")
        {
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<CardProvider> CardProviders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}