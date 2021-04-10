using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeaBoard.DataAccess.Migrations
{
    public partial class ContextIdeaBoardDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sessions");
        }
    }
}
