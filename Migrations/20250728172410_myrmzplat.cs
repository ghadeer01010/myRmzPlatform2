using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RmzPlatform.Migrations
{
    /// <inheritdoc />
    public partial class myrmzplat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrectCount",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Quiz",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TotalCount",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Quiz");
        }
    }
}
