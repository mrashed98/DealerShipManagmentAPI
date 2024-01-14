using DealerShip.Models;

namespace DealerShip.DTOs.GetDTOs
{
	public class SaleReadDto
	{
		public int SaleID { get; set; }
		public DateTime SaleDate { get; set; }
		public decimal TotalSalePrice { get; set; }
		public VehicleSaleReadDto? Vehicle { get; set; }
		public Customer? Customer { get; set; }
		public SalesPerson? SalesPerson { get; set; }
	}

}
