using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Store.Data.Migrations
{
    public partial class updateservicepettablle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetService");

            migrationBuilder.DropTable(
                name: "PetServiceDetail");

            migrationBuilder.CreateTable(
                name: "ServicePetDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    PetServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePetDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePetDetail");

            migrationBuilder.DropTable(
                name: "ServicePets");

            migrationBuilder.CreateTable(
                name: "PetService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetServiceDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    PetServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetServiceDetail", x => x.Id);
                });
        }
    }
}
