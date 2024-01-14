namespace DealerShip.DTOs.GetDTOs
{
	public class VehicleRentReadDto
	{
        public int VehicleID { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public decimal VehicleRentPrice { get; set; }
    }
}
