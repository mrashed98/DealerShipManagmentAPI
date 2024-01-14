using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealerShip.Models
{
	public class VehicleImage
	{
		[Key]
		public int ImageID { get; set; }

		[Required]
		public string ImageUrl { get; set; }

		[Required]
		public int VehicleID { get; set; }

		// Navigation property
		[ForeignKey("VehicleID")]
		public Vehicle Vehicle { get; set; }

		// Constructor
		public VehicleImage() { }

		public VehicleImage(string imageUrl, int vehicleId)
		{
			ImageUrl = imageUrl;
			VehicleID = vehicleId;
		}

		// Business logic methods
		public bool IsValidImageUrl()
		{
			// Example: Validate if the URL is correctly formatted
			Uri uriResult;
			bool result = Uri.TryCreate(ImageUrl, UriKind.Absolute, out uriResult)
				&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
			return result;
		}
	}

}
