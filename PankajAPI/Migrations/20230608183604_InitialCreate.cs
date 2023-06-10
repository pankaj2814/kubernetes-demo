using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PankajAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DOB = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DOB", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shakespeare" },
                    { 2, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jhon" },
                    { 3, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keets" },
                    { 4, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aristotle" },
                    { 5, new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chanakya" },
                    { 6, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balmiki" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
