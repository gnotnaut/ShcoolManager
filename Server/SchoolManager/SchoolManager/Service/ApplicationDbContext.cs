using Microsoft.EntityFrameworkCore;
using SchoolManager.Models;
using SchoolManager.Models.DTO;

namespace SchoolManager.Service
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<SinhVien> SinhViens { get; set; }
		public DbSet<MonHoc> MonHocs { get; set; }
		public DbSet<KetQua> KetQuas { get; set; }
		//public DbSet<SinhVienDTO> SinhVienDTOs { get; set; }  // Add this line

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MonHoc>()
				.HasKey(mh => mh.Mamh);
			modelBuilder.Entity<SinhVien>()
				.HasKey(sv => sv.Msv);

			modelBuilder.Entity<KetQua>()
				.HasKey(kq => new { kq.Msv, kq.Mamh });

			modelBuilder.Entity<KetQua>()
				.HasOne(kq => kq.SinhVien)
				.WithMany(sv => sv.KetQuas)
				.HasForeignKey(kq => kq.Msv);

			modelBuilder.Entity<KetQua>()
				.HasOne(kq => kq.MonHoc)
				.WithMany(mh => mh.KetQuas)
				.HasForeignKey(kq => kq.Mamh);



		}
	}
}
