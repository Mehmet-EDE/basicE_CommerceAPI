using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Ticaret.API.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "UserModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsAdmin",
                table: "UserModel",
                type: "text",
                nullable: true);
        }
    }
}
