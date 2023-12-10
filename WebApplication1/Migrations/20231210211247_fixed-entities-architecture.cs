using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegotiationApp.Migrations
{
    /// <inheritdoc />
    public partial class fixedentitiesarchitecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProposedPrice",
                table: "Negotiations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Negotiations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProposedPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Negotiations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProposedPrice",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProposedPrice",
                table: "Negotiations");
        }
    }
}
