using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowCopy.Migrations
{
    public partial class addedTableAnswear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answear_Questions_QuestionId",
                table: "Answear");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answear_AnswearId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answear",
                table: "Answear");

            migrationBuilder.RenameTable(
                name: "Answear",
                newName: "Answears");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answears",
                newName: "AnswearToQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answear_QuestionId",
                table: "Answears",
                newName: "IX_Answears_AnswearToQuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Answears",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answears",
                table: "Answears",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answears_Questions_AnswearToQuestionId",
                table: "Answears",
                column: "AnswearToQuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answears_AnswearId",
                table: "Comments",
                column: "AnswearId",
                principalTable: "Answears",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answears_Questions_AnswearToQuestionId",
                table: "Answears");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Answears_AnswearId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answears",
                table: "Answears");

            migrationBuilder.RenameTable(
                name: "Answears",
                newName: "Answear");

            migrationBuilder.RenameColumn(
                name: "AnswearToQuestionId",
                table: "Answear",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answears_AnswearToQuestionId",
                table: "Answear",
                newName: "IX_Answear_QuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Answear",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answear",
                table: "Answear",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answear_Questions_QuestionId",
                table: "Answear",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Answear_AnswearId",
                table: "Comments",
                column: "AnswearId",
                principalTable: "Answear",
                principalColumn: "Id");
        }
    }
}
