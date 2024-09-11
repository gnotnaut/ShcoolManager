namespace SchoolManager.Models.DTO
{
	public class KetQuaDTO
	{
		//public string Msv { get; set; }
		//public string Mamh { get; set; }
		public string TenSV { get; set; }
		public string TenMon { get; set; }
		public double Diem { get; set; }

		public KetQuaDTO() { }

		public KetQuaDTO(string tenSV, string tenMon, double diem)
		{
			TenSV = tenSV;
			TenMon = tenMon;
			Diem = diem;
		}
	}
}
