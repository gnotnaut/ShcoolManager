using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SchoolManager.Models.DTO
{
	public class SinhVienDTO
	{
		public  string Msv { get; set; }
		public  string Hoten { get; set; }
		public  DateTime Ngaysinh { get; set; }
		public  string Gioitinh { get; set; }
		public  string Diachi { get; set; }
		public  string Dienthoai { get; set; }
		public  string Makhoa { get; set; }

		public ICollection<KetQuaDTO> KetQuaDTOs { get; set; }
		public SinhVienDTO()
		{
		
		}
		public SinhVienDTO(string msv, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string dienthoai, string makhoa, ICollection<KetQuaDTO> ketQuaDTOs)
		{
			Msv = msv;
			Hoten = hoten;
			Ngaysinh = ngaysinh;
			Gioitinh = gioitinh;
			Diachi = diachi;
			Dienthoai = dienthoai;
			Makhoa = makhoa;
			KetQuaDTOs = ketQuaDTOs;
		}
	}
}
