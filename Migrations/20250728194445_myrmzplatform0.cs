using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RmzPlatform.Migrations
{
    /// <inheritdoc />
    public partial class myrmzplatform0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Result_ResultId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_ResultId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "CorrectCount",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Quiz");

            migrationBuilder.RenameColumn(
                name: "TotalCount",
                table: "Result",
                newName: "CorrectAnswers");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Result",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Quiz",
                newName: "QuestionText");

            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "LanguageDetails",
                newName: "Overview");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "LanguageDetails",
                newName: "ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Result",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionD",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Language",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionD",
                table: "Quiz");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Result",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswers",
                table: "Result",
                newName: "TotalCount");

            migrationBuilder.RenameColumn(
                name: "QuestionText",
                table: "Quiz",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "Overview",
                table: "LanguageDetails",
                newName: "LogoUrl");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "LanguageDetails",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Result",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CorrectCount",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Quiz",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_ResultId",
                table: "Quiz",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Result_ResultId",
                table: "Quiz",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id");
        }
    }
}
