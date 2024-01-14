using System.ComponentModel.DataAnnotations;

namespace DealerShip.Models
{
	public class VehicleStatus
	{
		[Key]
		public int VehicleStatusID { get; set; }

		[Required, MaxLength(50)]
		public string StatusName { get; set; }

		// Navigation property back to Vehicle
		public virtual ICollection<Vehicle> Vehicles { get; set; }

		// Constructor
		public VehicleStatus()
		{
			Vehicles = new HashSet<Vehicle>();
		}

		// Constructor for initializing a VehicleStatus with a name
		public VehicleStatus(string statusName) : this()
		{
			StatusName = statusName;
		}

		// Additional methods for business rules and validations can be added here
	}

}
