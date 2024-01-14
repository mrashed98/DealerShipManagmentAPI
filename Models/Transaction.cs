using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealerShip.Models
{
	public abstract class Transaction
	{
		[Key]
		public int TransactionID { get; set; }

		[Required]
		public int VehicleID { get; set; }
		[Required]
		public int ModelID { get; set; }

        [Required]
		public int CustomerID { get; set; }
        public int SalesPersonID { get; set; }

        public DateTime TransactionDate { get; set; }

		// New field for transaction amount
		[Column(TypeName = "decimal(18, 2)")]
		public decimal TransactionAmount { get; set; }

		// Navigation properties
		[ForeignKey("VehicleID")]
		public virtual Vehicle? Vehicle { get; set; }

		// Navigation properties
		[ForeignKey("ModelID")]
		public virtual Model? Model { get; set; }

		[ForeignKey("CustomerID")]
		public virtual Customer? Customer { get; set; }
		[ForeignKey("SalesPersonID")]
		public virtual SalesPerson? SalesPerson { get; set; }

		// Constructor for Entity Framework
		protected Transaction() { }

		// Constructor to initialize a Transaction
		protected Transaction(int vehicleId, int customerId, DateTime transactionDate, decimal transactionAmount)
		{
			VehicleID = vehicleId;
			CustomerID = customerId;
			SalesPersonID = SalesPersonID;
			TransactionDate = transactionDate;
			TransactionAmount = transactionAmount;
		}

		// Common transaction methods can be defined here
	}

}
