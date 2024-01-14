using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealerShip.Models
{
	public class Rent : Transaction
	{
		public DateTime EndDate { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public decimal InsuranceAmount { get; set; }

		// Constructor without parameters for Entity Framework
		public Rent() : base() { }

		// Updated constructor for creating a Rent transaction
		public Rent(int vehicleId, int customerId, DateTime transactionDate, decimal transactionAmount,
					 DateTime endDate, decimal insuranceAmount)
			: base(vehicleId, customerId, transactionDate, transactionAmount)
		{
			EndDate = endDate;
			InsuranceAmount = insuranceAmount;
		}

		// Business logic methods
		public bool IsCurrentlyRented()
		{
			return DateTime.UtcNow >= TransactionDate && DateTime.UtcNow <= EndDate;
		}

		public int GetRentalDurationInDays()
		{
			return (EndDate - TransactionDate).Days;
		}
	}

}
