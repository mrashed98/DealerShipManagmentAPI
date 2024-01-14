using System.ComponentModel.DataAnnotations;

namespace DealerShip.Models
{
	public class Make
	{
		[Key]
		public int MakeID { get; set; }
		public string MakeName { get; set; }

		// Navigation property for related models
		public virtual ICollection<Model> Models { get; set; }

		// Constructor without parameters for Entity Framework
		public Make()
		{
			Models = new HashSet<Model>();
		}

		// Constructor for initializing a Make with a name
		public Make(string makeName) : this()
		{
			MakeName = makeName;
		}
	}

}
