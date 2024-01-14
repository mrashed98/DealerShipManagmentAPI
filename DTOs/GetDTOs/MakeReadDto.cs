namespace DealerShip.DTOs.GetDTOs
{
	public class MakeReadDto
	{
		public int MakeID { get; set; }
		public string MakeName { get; set; }
		public List<ModelReadDto> Models { get; set; }

        public MakeReadDto()
        {
            Models = new List<ModelReadDto>();
			MakeName = "Unkown Maker";
        }
    }
}
