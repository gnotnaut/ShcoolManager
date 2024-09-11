namespace SchoolManager.Models.DTO
{
	public class MonHocDTO
	{
		public string Mamh { get; set; }
		public string Tenmh { get; set; }
		public int Sotiet { get; set; }

		public ICollection<KetQuaDTO> KetQuaDTOs { get; set; }

		public MonHocDTO()
		{

		}

		public MonHocDTO(string mamh, string tenmh, int sotiet, ICollection<KetQuaDTO> ketQuaDTOs)
		{
			Mamh = mamh;
			Tenmh = tenmh;
			Sotiet = sotiet;
			KetQuaDTOs = ketQuaDTOs;
		}
	}
}
