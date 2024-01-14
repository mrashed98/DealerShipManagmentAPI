using DealerShip.Models;
using Microsoft.EntityFrameworkCore;

namespace DealerShip.Presistance
{
	public class ApplicationDBContext: DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> DbOptions) : base(DbOptions)
		{

		}

		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<VehicleImage> VehicleImages { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<SalesPerson> SalesPersons { get; set; }
		public DbSet<Make> Makes { get; set; }
		public DbSet<Model> Models { get; set; }
		public DbSet<Rent> Rents { get; set; }
		public DbSet<Sale> Sales { get; set; }
		public DbSet<VehicleStatus> VehicleStatuses { get; set; }


		// Override the OnModelCreating method to configure the model
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Example of configuring the Vehicle entity
			modelBuilder.Entity<Vehicle>(entity =>
			{
				entity.ToTable("Vehicles");

				// Configuring a one-to-many relationship with VehicleImage
				entity.HasMany(v => v.VehicleImages)
					  .WithOne(i => i.Vehicle)
					  .HasForeignKey(i => i.VehicleID);

				// Additional configurations can be added here
			});

			// Configurations for other entities can be defined in a similar manner

			// Setting up inheritance for the Transaction hierarchy
			modelBuilder.Entity<Transaction>()
				.HasDiscriminator<string>("TransactionType")
				.HasValue<Rent>("Rent")
				.HasValue<Sale>("Sale");

			modelBuilder.Entity<VehicleStatus>(entity =>
			{
				entity.ToTable("VehicleStatuses");

				// If you have specific configurations for VehicleStatus, add them here
			});
		}
	}
}
