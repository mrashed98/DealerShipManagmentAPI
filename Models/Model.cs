using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealerShip.Models
{
	public class Model
	{
		[Key]
		public int ModelID { get; set; }
		public string ModelName { get; set; }

		// Foreign key to associate the model with a make
		public int MakeID { get; set; }

		// Navigation property back to Make
		[ForeignKey("MakeID")]
		public virtual Make Make { get; set; }

		// Constructor without parameters for Entity Framework
		public Model()
		{
		}

		// Constructor for initializing a Model with a name and associated make ID
		public Model(string modelName, int makeId)
		{
			ModelName = modelName;
			MakeID = makeId;
		}
	}

}
