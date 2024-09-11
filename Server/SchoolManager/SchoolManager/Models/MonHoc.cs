using System.Text.Json.Serialization;

namespace SchoolManager.Models
{
	public class MonHoc
	{
		public string Mamh { get; set; }
		public string Tenmh { get; set; }
		public int Sotiet { get; set; }
		[JsonIgnore]
		public ICollection<KetQua>? KetQuas { get; set; }
	}
}
