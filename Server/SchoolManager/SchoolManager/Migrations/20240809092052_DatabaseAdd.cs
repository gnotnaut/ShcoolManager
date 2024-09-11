using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManager.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    Mamh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenmh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sotiet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.Mamh);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    Msv = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "date", nullable: false),
                    Gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dienthoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Makhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.Msv);
                });

            migrationBuilder.CreateTable(
                name: "KetQuas",
                columns: table => new
                {
                    Msv = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mamh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Diem = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuas", x => new { x.Msv, x.Mamh });
                    table.ForeignKey(
                        name: "FK_KetQuas_MonHocs_Mamh",
                        column: x => x.Mamh,
                        principalTable: "MonHocs",
                        principalColumn: "Mamh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KetQuas_SinhViens_Msv",
                        column: x => x.Msv,
                        principalTable: "SinhViens",
                        principalColumn: "Msv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_Mamh",
                table: "KetQuas",
                column: "Mamh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KetQuas");

            migrationBuilder.DropTable(
                name: "MonHocs");

            migrationBuilder.DropTable(
                name: "SinhViens");
        }
    }
}
