using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addseofields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SEODescription",
                table: "Pages",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTitle",
                table: "Pages",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEODescription",
                table: "Loans",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTitle",
                table: "Loans",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEODescription",
                table: "Contents",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTitle",
                table: "Contents",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SEODescription",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "SEOTitle",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "SEODescription",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "SEOTitle",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "SEODescription",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "SEOTitle",
                table: "Contents");
        }
    }
}
