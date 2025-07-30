using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RmzPlatform.Migrations
{
    /// <inheritdoc />
    public partial class mymigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageDetails_Language_LanguageId",
                table: "LanguageDetails");

            migrationBuilder.DropIndex(
                name: "IX_LanguageDetails_LanguageId",
                table: "LanguageDetails");

            migrationBuilder.DropColumn(
                name: "Choices",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "CorrectChoiceIndex",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "OptionD",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "LanguageDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Result",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "SubmittedAt",
                table: "Result",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Quiz",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LanguageDetails",
                newName: "LogoUrl");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "LanguageDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageDetails_LanguageId",
                table: "LanguageDetails",
                column: "LanguageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageDetails_Language_LanguageId",
                table: "LanguageDetails",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageDetails_Language_LanguageId",
                table: "LanguageDetails");

            migrationBuilder.DropIndex(
                name: "IX_LanguageDetails_LanguageId",
                table: "LanguageDetails");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Result",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Result",
                newName: "SubmittedAt");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Quiz",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "LanguageDetails",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Choices",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CorrectChoiceIndex",
                table: "Quiz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OptionD",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "LanguageDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "LanguageDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Language",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageDetails_LanguageId",
                table: "LanguageDetails",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageDetails_Language_LanguageId",
                table: "LanguageDetails",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id");
        }
    }
}
