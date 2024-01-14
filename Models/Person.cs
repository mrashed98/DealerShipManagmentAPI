namespace DealerShip.Models
{
	public abstract class Person
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string NationalID { get; set; }
        public string LicenseID { get; set; }

    }
}
