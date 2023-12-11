using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegotiationApp.Migrations
{
    /// <inheritdoc />
    public partial class removeduselessfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegotiationTries",
                table: "Attempts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NegotiationTries",
                table: "Attempts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Attempts",
                keyColumn: "Id",
                keyValue: 1,
                column: "NegotiationTries",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Attempts",
                keyColumn: "Id",
                keyValue: 2,
                column: "NegotiationTries",
                value: 0);
        }
    }
}
