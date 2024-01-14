using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealerShip.Models
{
	public class Vehicle
	{
		[Key]
		public int VehicleID { get; set; }

		[Required]
		public int VehicleModelID { get; set; }

		[Required]
		public int VehicleMakeID { get; set; }

		[Required]
		public string VehicleType { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal VehicleMileage { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal VehicleRentPrice { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal VehicleSalePrice { get; set; }

		public DateTime VehicleProductionDate { get; set; }

		public virtual ICollection<VehicleImage> VehicleImages { get; set; }
		public virtual Make VehicleMake { get; set; }
		public virtual Model VehicleModel { get; set; }

		// Foreign key for VehicleStatus
		public int VehicleStatusID { get; set; }

		// Navigation property for VehicleStatus
		[ForeignKey("VehicleStatusID")]
		public virtual VehicleStatus VehicleStatus { get; set; }

		public Vehicle()
		{
			// Initialization of collections if needed
			VehicleImages = new HashSet<VehicleImage>();
		
		}

		public Vehicle(int modelID, int makeID, string type, decimal mileage, decimal rentPrice, decimal salePrice, DateTime productionDate) : this()
		{
			VehicleModelID = modelID;
			VehicleMakeID = makeID;
			VehicleType = type;
			VehicleMileage = mileage;
			VehicleRentPrice = rentPrice;
			VehicleSalePrice = salePrice;
			VehicleProductionDate = productionDate;
			// VehicleStatus could be initialized to a default value, like "Available"
			VehicleStatus = new VehicleStatus("Available");
		}

		// Business logic methods
		public decimal CalculateDepreciation(int ageInYears)
		{
			// Assuming a simple straight-line depreciation for the example
			decimal depreciationRate = 0.15M; // 15% per year
			return VehicleSalePrice * (1 - (depreciationRate * ageInYears));
		}

		public void UpdateStatus(string status)
		{
			// Perform any necessary validation or additional logic before updating
			VehicleStatus.StatusName = status;
		}

	}
}
