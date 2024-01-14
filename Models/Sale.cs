using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealerShip.Models
{
	public class Sale : Transaction
	{



		// Constructor without parameters for Entity Framework
		public Sale() : base() { }

		// Updated constructor for creating a Sale transaction
		public Sale(int vehicleId, int customerId, int salesPersonId, DateTime transactionDate, decimal transactionAmount)
			: base(vehicleId, customerId, transactionDate, transactionAmount)
		{
		}
		// Business logic methods
		public bool IsRecentSale()
		{
			// Define what you consider as "recent"
			var recentPeriod = TimeSpan.FromDays(30);
			return DateTime.UtcNow - TransactionDate < recentPeriod;
		}
	}

}
