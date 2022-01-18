using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesSoccer.Migrations
{
    public partial class v002AddClubPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Club",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Club");
        }
    }
}
