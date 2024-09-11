using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Models;
using SchoolManager.Models.DTO;
using SchoolManager.Service;
using System.Collections.Generic;

namespace SchoolManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SinhVienController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public SinhVienController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<SinhVien>>> GetSinhViens()
		{
			var listSv= await _context.SinhViens
				.Include(sv => sv.KetQuas)
				.ThenInclude(kq => kq.MonHoc)
				.ToListAsync();
			var listsvDto =listSv .Select(sv => new SinhVienDTO
			{
				Msv = sv.Msv,
				Hoten = sv.Hoten,
				Ngaysinh = sv.Ngaysinh,
				Gioitinh = sv.Gioitinh,
				Diachi = sv.Diachi,
				Dienthoai = sv.Dienthoai,
				Makhoa = sv.Makhoa,


				KetQuaDTOs = sv.KetQuas.Select(kq => new KetQuaDTO
				{
					Diem = kq.Diem,
					TenSV=kq.SinhVien.Hoten,
					TenMon = kq.MonHoc.Tenmh,
					
				}).ToList()
			}).ToList();


			return Ok(listsvDto);

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<SinhVien>> GetSinhVien(string id)
		{
			var sinhVien = await _context.SinhViens
				.Include(sv => sv.KetQuas)
				.ThenInclude(kq => kq.MonHoc)
				.FirstOrDefaultAsync(sv => sv.Msv == id);

			if (sinhVien == null)
			{
				return NotFound();
			}

			var sinhVienDTO = new SinhVienDTO(
				sinhVien.Msv,
				sinhVien.Hoten,
				sinhVien.Ngaysinh,
				sinhVien.Gioitinh,
				sinhVien.Diachi,
				sinhVien.Dienthoai,
				sinhVien.Makhoa,
				sinhVien.KetQuas.Select(kq => new KetQuaDTO
				{
					Diem = kq.Diem,
					TenSV = kq.SinhVien.Hoten,
					TenMon = kq.MonHoc.Tenmh,

				}).ToList()
			);
			
			


			

			return Ok(sinhVienDTO);
		}

		[HttpPost]
		public async Task<ActionResult<SinhVien>> PostSinhVien(SinhVien sinhVien)
		{
			//var sinhVien = new SinhVien();
			//sinhVien.Msv = sinhVienDTO.Msv;
			//sinhVien.Hoten = sinhVienDTO.Hoten;
			//sinhVien.Ngaysinh = sinhVienDTO.Ngaysinh;
			//sinhVien.Gioitinh = sinhVienDTO.Gioitinh;
			//sinhVien.Diachi=sinhVienDTO.Diachi;
			//sinhVien.Dienthoai=sinhVienDTO.Dienthoai;
			//sinhVien.Makhoa = sinhVienDTO.Makhoa;


			_context.SinhViens.Add(sinhVien);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetSinhVien), new { id = sinhVien.Msv }, sinhVien);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutSinhVien(string id, SinhVien sinhVien)
		{
			//var sinhVien = new SinhVien();
			//sinhVien.Msv = sinhVienDTO.Msv;
			//sinhVien.Hoten = sinhVienDTO.Hoten;
			//sinhVien.Ngaysinh = sinhVienDTO.Ngaysinh;
			//sinhVien.Gioitinh = sinhVienDTO.Gioitinh;
			//sinhVien.Diachi = sinhVienDTO.Diachi;
			//sinhVien.Dienthoai = sinhVienDTO.Dienthoai;
			//sinhVien.Makhoa = sinhVienDTO.Makhoa; 
			if (id != sinhVien.Msv)
			{
				return BadRequest();
			}

			_context.Entry(sinhVien).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSinhVien(string id)
		{
			var sinhVien = await _context.SinhViens.FindAsync(id);
			if (sinhVien == null)
			{
				return NotFound();
			}

			_context.SinhViens.Remove(sinhVien);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
