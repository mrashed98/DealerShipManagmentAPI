namespace DealerShip.DTOs.PostDTOs
{
	public class VehicleCreateDto
	{
		public int VehicleModelID { get; set; }
		public int VehicleMakeID { get; set; }
		public string VehicleType { get; set; }
		public decimal VehicleMileage { get; set; }
		public decimal VehicleRentPrice { get; set; }
		public decimal VehicleSalePrice { get; set; }
		public DateTime VehicleProductionDate { get; set; }
		public string VehicleStatusName { get; set; }
	}
}
