using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DealerShip.Models
{
	public class Customer : Person
	{

		

		// Constructor without parameters for Entity Framework
		public Customer()
		{
			
		}

		// Constructor for creating a new Customer with basic details
		public Customer(string name, string email, string phone, string licensee, string nationalId) : base()
		{
			Name = name;
			Email = email;
			Phone = phone;
			LicenseID = licensee;
			NationalID = nationalId;
		}

		// Business logic methods

		// Method to validate the format of the national ID, this will depend on your country's format
		public bool IsValidNationalID(string nationalId)
		{
			// Example: Regex for a fictitious national ID format
			var regexPattern = @"^[0-9]{10}$";
			return Regex.IsMatch(nationalId, regexPattern);
		}
		
		// Method to update customer contact details
		public void UpdateContactDetails(string email, string phone)
		{
			Email = email;
			Phone = phone;
		}

		// Additional methods can be added as necessary, such as for validating the customer's age, credit score checks, etc.
	}
}
