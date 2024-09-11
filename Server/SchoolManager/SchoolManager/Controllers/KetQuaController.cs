using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SchoolManager.Models;
using SchoolManager.Models.DTO;
using SchoolManager.Service;
using static SchoolManager.Models.KetQua;

namespace SchoolManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KetQuaController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public KetQuaController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("test")]
		public async Task<ActionResult<IEnumerable<KetQua>>> GetKetQuasTest()
		{
			var ketqua = _context.KetQuas
				.Join(_context.SinhViens,
				kq => kq.Msv,
				sv=>sv.Msv,
				(ketqua, sinhvien) => new
				{
					StudentName=sinhvien.Hoten,
					Diem=ketqua.Diem,
				}


				).ToList();
			return Ok(ketqua);
		}




		[HttpGet]
		//[Route("all")]
		public async Task<ActionResult<IEnumerable<KetQua>>> GetKetQuas()
		{


			var ketqua = await _context.KetQuas
				.Include(k => k.SinhVien)
			.Include(k => k.MonHoc)
			.ToListAsync();
			var ketQuasDTO = ketqua.Select(kq => new KetQuaDTO
			{
				//Msv = kq.Msv,
				//Mamh = kq.Mamh,
				Diem = kq.Diem,
				TenSV = kq.SinhVien.Hoten,
				TenMon = kq.MonHoc.Tenmh
			}).ToList();
			return Ok(ketQuasDTO);

			//return await _context.KetQuas
			//	.Include(k => k.SinhVien)
			//	.Include(k => k.MonHoc)
			//	.ToListAsync();

		}

		[HttpGet("{msv}/{mamh}")]
		public async Task<ActionResult<KetQua>> GetKetQua(string msv, string mamh)
		{
			var ketQua = await _context.KetQuas
				.Include(k => k.SinhVien)
				.Include(k => k.MonHoc)
				.FirstOrDefaultAsync(kq => kq.Msv == msv && kq.Mamh == mamh);

			if (ketQua == null)
			{
				return NotFound();
			}


			var KetquaDto = new KetQuaDTO(ketQua.SinhVien.Hoten, ketQua.MonHoc.Tenmh, ketQua.Diem);

			return Ok(KetquaDto);
		}
	

		// PUT: api/KetQuas/5
		[HttpPut("{msv}/{mamh}")]
		public async Task<IActionResult> PutKetQua(string msv, string mamh, KetQua ketQua)
		{
			//var ketQua = new KetQua();
			//ketQua.Msv = ketQuaDTO.Msv;
			//ketQua.Mamh = ketQuaDTO.Mamh;
			//ketQua.Diem = ketQuaDTO.Diem;

			if (msv != ketQua.Msv || mamh != ketQua.Mamh)
			{
				return BadRequest();
			}

			_context.Entry(ketQua).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!KetQuaExists(msv, mamh))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/KetQuas
		[HttpPost]
		public async Task<ActionResult<KetQua>> PostKetQua(KetQua ketQua)
		{
			//var ketQua =new KetQua();
			//ketQua.Msv=ketQuaDTO.Msv;
			//ketQua.Mamh=ketQuaDTO.Mamh;
			//ketQua.Diem= ketQuaDTO.Diem;

			_context.KetQuas.Add(ketQua);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetKetQua), new { msv = ketQua.Msv, mamh = ketQua.Mamh }, ketQua);
		}

		// DELETE: api/KetQuas/5
		[HttpDelete("{msv}/{mamh}")]
		public async Task<IActionResult> DeleteKetQua(string msv, string mamh)
		{
			var ketQua = await _context.KetQuas.FindAsync(msv, mamh);
			if (ketQua == null)
			{
				return NotFound();
			}

			_context.KetQuas.Remove(ketQua);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool KetQuaExists(string msv, string mamh)
		{
			return _context.KetQuas.Any(e => e.Msv == msv && e.Mamh == mamh);
		}
	}
}

