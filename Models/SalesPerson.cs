namespace DealerShip.Models
{
	public class SalesPerson : Person
	{
		// SalesPerson-specific properties
		public string Status { get; set; }
		public DateTime HiringDate { get; set; } = DateTime.Now;

		// Navigation property for the sales they are involved in

		// Constructor without parameters for Entity Framework
		public SalesPerson()
		{
		}

		// Constructor for creating a new SalesPerson with basic details
		public SalesPerson(string name, string email, string phone, string status, string address, string license, string nationalID, DateTime hiringDate) : base()
		{
			Name = name;
			Email = email;
			Phone = phone;
			Status = status;
			Address = address;
			NationalID = nationalID;
			LicenseID = license;
			HiringDate = hiringDate;
		}

		// Business logic methods

		// Example: Method to calculate years of service
		public int CalculateYearsOfService()
		{
			return (DateTime.Now - HiringDate).Days / 365; // Simplified calculation
		}

		// Add any SalesPerson-specific methods here
	}

}
