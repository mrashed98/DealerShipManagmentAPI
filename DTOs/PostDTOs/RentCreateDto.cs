namespace DealerShip.DTOs.PostDTOs
{
	public class RentCreateDto
	{
        public int VehicleID { get; set; }
        public int ModelID { get; set; }
        public int CustomerID { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SalesPersonID { get; set; }
        public decimal InsuranceAmout { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}
