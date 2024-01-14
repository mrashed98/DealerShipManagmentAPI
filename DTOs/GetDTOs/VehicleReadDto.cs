namespace DealerShip.DTOs.GetDTOs
{
	public class VehicleReadDto
	{
        public int VehicleID { get; set; }
        public string VehicleModel { get; set; }
		public string VehicleMake { get; set; }
		public string VehicleType { get; set; }
		public decimal VehicleMileage { get; set; }
		public decimal VehicleRentPrice { get; set; }
		public decimal VehicleSalePrice { get; set; }
		public DateTime VehicleProductionDate { get; set; }
		public VehicleStatusDto? VehicleState { get; set; }
		public List<string>? VehicleImages { get; set; }

	}
}
