using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Models;
using SchoolManager.Models.DTO;
using SchoolManager.Service;

namespace SchoolManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MonHocController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public MonHocController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<MonHoc>>> GetMonHocs()
		{
			var listMon= await _context.MonHocs
				.Include(mh => mh.KetQuas)
				.ThenInclude(kq => kq.SinhVien)
				.ToListAsync();

			var listMonDTO = listMon.Select(mon=>new MonHocDTO { 
				Mamh=mon.Mamh,
				Tenmh=mon.Tenmh,
				Sotiet=mon.Sotiet,
				KetQuaDTOs=mon.KetQuas.Select(kq=>new KetQuaDTO { 
					Diem=kq.Diem,
					TenMon=kq.MonHoc.Tenmh,
					TenSV=kq.SinhVien.Hoten,
				}).ToList(),
			}).ToList();


			return Ok(listMonDTO);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<MonHoc>> GetMonHoc(string id)
		{
			var monHoc = await _context.MonHocs.
				Include(mh => mh.KetQuas).
				ThenInclude(kq => kq.SinhVien).
				FirstOrDefaultAsync(mh => mh.Mamh == id);
			//FindAsync(id);
			if (monHoc == null)
			{
				return NotFound();
			}

			var MonHocDTO = new MonHocDTO(
					monHoc.Mamh,
					monHoc.Tenmh,
					monHoc.Sotiet,
					monHoc.KetQuas.Select(kq => new KetQuaDTO
					{
						TenSV=kq.SinhVien.Hoten,
						TenMon=kq.MonHoc.Tenmh,
						Diem=kq.Diem
					}).ToList()
				);
			return Ok(MonHocDTO);
		}

		[HttpPost]
		public async Task<ActionResult<MonHoc>> PostMonHoc(MonHoc monHoc)
		{
			_context.MonHocs.Add(monHoc);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetMonHoc), new { id = monHoc.Mamh }, monHoc);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutMonHoc(string id, MonHoc monHoc)
		{
			if (id != monHoc.Mamh)
			{
				return BadRequest();
			}

			_context.Entry(monHoc).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMonHoc(string id)
		{
			var monHoc = await _context.MonHocs.FindAsync(id);
			if (monHoc == null)
			{
				return NotFound();
			}

			_context.MonHocs.Remove(monHoc);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
