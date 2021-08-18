using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShop.Infrastructure.Migrations
{
    public partial class Update_Product_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Pro_ImportDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pro_ImportDate",
                table: "Products");
        }
    }
}
