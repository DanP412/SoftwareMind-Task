using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NegotiationApp.Migrations
{
    /// <inheritdoc />
    public partial class nullableEmmployeeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negotiations_Emoployees_EmployeeId",
                table: "Negotiations");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Negotiations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Negotiations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Negotiations_Emoployees_EmployeeId",
                table: "Negotiations",
                column: "EmployeeId",
                principalTable: "Emoployees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negotiations_Emoployees_EmployeeId",
                table: "Negotiations");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Negotiations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Negotiations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Negotiations_Emoployees_EmployeeId",
                table: "Negotiations",
                column: "EmployeeId",
                principalTable: "Emoployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
