using DealerShip.Models;

namespace DealerShip.DTOs.GetDTOs
{
	public class RentReadDto
	{
		public int RentID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public decimal TotalRentPrice { get; set; }
        public VehicleRentReadDto Vehicle { get; set; }
        public Customer Customer { get; set; }
        public SalesPerson SalesPerson { get; set; }
    }
}
