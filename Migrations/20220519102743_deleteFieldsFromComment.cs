using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowCopy.Migrations
{
    public partial class deleteFieldsFromComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentAnswear",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentQuestion",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CommentAnswear",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CommentQuestion",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
