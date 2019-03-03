using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Data.Migrations
{
    public partial class ProductPhoto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Products");
        }
    }
}
