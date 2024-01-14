namespace DealerShip.DTOs.PostDTOs
{
	public class ModelCreateDto
	{
		public string ModelName { get; set; }
        public ModelCreateDto()
        {
            ModelName = "Unkown Model";
        }
    }
}
