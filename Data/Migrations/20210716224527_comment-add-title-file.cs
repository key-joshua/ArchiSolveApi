using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class commentaddtitlefile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderTitle",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceFileName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderTitle",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SourceFileName",
                table: "Comments");
        }
    }
}
