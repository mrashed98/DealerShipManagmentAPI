namespace DealerShip.DTOs.PostDTOs
{
	public class MakeCreateDto
	{
		public string MakeName { get; set; }
		public List<ModelCreateDto> Models { get; set; }

        public MakeCreateDto()
        {
            Models = new List<ModelCreateDto>();
            MakeName = "UnKownMaker";
        }
    }
}
