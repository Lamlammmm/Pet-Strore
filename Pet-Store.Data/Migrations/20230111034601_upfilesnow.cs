using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Store.Data.Migrations
{
    public partial class upfilesnow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Size = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    AboutId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
