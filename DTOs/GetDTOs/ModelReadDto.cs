namespace DealerShip.DTOs.GetDTOs
{
	public class ModelReadDto
	{
		public int ModelID { get; set; }
		public string ModelName { get; set; }

        public ModelReadDto()
        {
            ModelName = "Unkown Model";
        }
    }
}
