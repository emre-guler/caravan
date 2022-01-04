using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caravan.Migrations
{
    public partial class PasswordSaltRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Customers",
                type: "text",
                nullable: true);
        }
    }
}
