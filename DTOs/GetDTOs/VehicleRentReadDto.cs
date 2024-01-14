namespace DealerShip.DTOs.GetDTOs
{
	public class VehicleRentReadDto
	{
        public int VehicleID { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public decimal VehicleRentPrice { get; set; }
    }
}
