﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManager.Service;

#nullable disable

namespace SchoolManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolManager.Models.KetQua", b =>
                {
                    b.Property<string>("Msv")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Mamh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Diem")
                        .HasColumnType("float");

                    b.HasKey("Msv", "Mamh");

                    b.HasIndex("Mamh");

                    b.ToTable("KetQuas");
                });

            modelBuilder.Entity("SchoolManager.Models.MonHoc", b =>
                {
                    b.Property<string>("Mamh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Sotiet")
                        .HasColumnType("int");

                    b.Property<string>("Tenmh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Mamh");

                    b.ToTable("MonHocs");
                });

            modelBuilder.Entity("SchoolManager.Models.SinhVien", b =>
                {
                    b.Property<string>("Msv")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Diachi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dienthoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gioitinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hoten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Makhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("datetime2");

                    b.HasKey("Msv");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("SchoolManager.Models.KetQua", b =>
                {
                    b.HasOne("SchoolManager.Models.MonHoc", "MonHoc")
                        .WithMany("KetQuas")
                        .HasForeignKey("Mamh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManager.Models.SinhVien", "SinhVien")
                        .WithMany("KetQuas")
                        .HasForeignKey("Msv")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonHoc");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("SchoolManager.Models.MonHoc", b =>
                {
                    b.Navigation("KetQuas");
                });

            modelBuilder.Entity("SchoolManager.Models.SinhVien", b =>
                {
                    b.Navigation("KetQuas");
                });
#pragma warning restore 612, 618
        }
    }
}
