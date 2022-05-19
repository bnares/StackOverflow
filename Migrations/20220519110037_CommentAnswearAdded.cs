using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowCopy.Migrations
{
    public partial class CommentAnswearAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answears_AnswearId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnswearId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnswearId",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "CommentAnswears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswearId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentAnswears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentAnswears_Answears_AnswearId",
                        column: x => x.AnswearId,
                        principalTable: "Answears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentAnswears_AnswearId",
                table: "CommentAnswears",
                column: "AnswearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentAnswears");

            migrationBuilder.AddColumn<int>(
                name: "AnswearId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnswearId",
                table: "Comments",
                column: "AnswearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answears_AnswearId",
                table: "Comments",
                column: "AnswearId",
                principalTable: "Answears",
                principalColumn: "Id");
        }
    }
}
