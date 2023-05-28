using credit_card_app_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace credit_card_app_backend
{
	// Class ApplicationDBContext allows creating a Database from a class model
	public class ApplicationDBContext : DbContext
    {
        // Map the model to the dbCreditCards database tables
        public DbSet<CreditCard> dbCreditCards { get; set; }

		// Constructor without parameter to able the migration construction
		public ApplicationDBContext() : base()
		{
		}

		// Create a controller
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
		}

        // Sets the database connection
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            if(!optionsBuilder.IsConfigured)
            {
				optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=dbCreditCards;Trusted_Connection=true;MultipleActiveResultSets=true;Encrypt=false");
			}
		}
	}
}
