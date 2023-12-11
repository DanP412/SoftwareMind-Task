using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegotiationApp.Migrations
{
    /// <inheritdoc />
    public partial class fixeddeletingrecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attempts_Negotiations_NegotiationId",
                table: "Attempts");

            migrationBuilder.AddForeignKey(
                name: "FK_Attempts_Negotiations_NegotiationId",
                table: "Attempts",
                column: "NegotiationId",
                principalTable: "Negotiations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attempts_Negotiations_NegotiationId",
                table: "Attempts");

            migrationBuilder.AddForeignKey(
                name: "FK_Attempts_Negotiations_NegotiationId",
                table: "Attempts",
                column: "NegotiationId",
                principalTable: "Negotiations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
