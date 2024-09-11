using SchoolManager.Models.DTO;
using System.Text.Json.Serialization;

namespace SchoolManager.Models
{
	public class KetQua
	{
		public string Msv { get; set; }
		public string Mamh { get; set; }
		public double Diem { get; set; }
		[JsonIgnore]
		public SinhVien? SinhVien { get; set; }

		[JsonIgnore]
		public MonHoc? MonHoc { get; set; }
	}
}
