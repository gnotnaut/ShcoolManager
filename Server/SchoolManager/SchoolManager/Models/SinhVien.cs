using System.Text.Json.Serialization;

namespace SchoolManager.Models
{
	public class SinhVien
	{
		public string Msv { get; set; }
		public  string Hoten { get; set; }
		public  DateTime Ngaysinh { get; set; }
		public  string Gioitinh { get; set; }
		public  string Diachi { get; set; }
		public  string Dienthoai { get; set; }
		public  string Makhoa { get; set; }
		[JsonIgnore]
		public ICollection<KetQua>? KetQuas { get; set; }
	}
}
