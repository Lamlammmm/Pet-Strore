using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Store.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PetServiceId",
                table: "PetServiceDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TypeMenu",
                table: "MenuItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "BlogId",
                table: "BlogDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductDetail");

            migrationBuilder.DropColumn(
                name: "PetServiceId",
                table: "PetServiceDetail");

            migrationBuilder.DropColumn(
                name: "TypeMenu",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "BlogDetail");
        }
    }
}
