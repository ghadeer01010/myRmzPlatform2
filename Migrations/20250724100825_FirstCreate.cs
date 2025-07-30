using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RmzPlatform.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Choices",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "CorrectChoiceIndex",
                table: "Quiz",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Choices",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "CorrectChoiceIndex",
                table: "Quiz");
        }
    }
}
