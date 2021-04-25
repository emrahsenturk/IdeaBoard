using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeaBoard.DataAccess.Migrations
{
    public partial class EmojiAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "EmojiId",
                table: "Ideas",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmojiId",
                table: "Ideas");
        }
    }
}
