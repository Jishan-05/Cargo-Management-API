using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__customer__user_i__3C69FB99",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "_user");

            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "employee",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK__customer__user_i__3C69FB99",
                table: "customer",
                column: "user_id",
                principalTable: "_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__customer__user_i__3C69FB99",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "position",
                table: "employee");

            migrationBuilder.AddColumn<byte[]>(
                name: "password_salt",
                table: "_user",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__customer__user_i__3C69FB99",
                table: "customer",
                column: "user_id",
                principalTable: "_user",
                principalColumn: "id");
        }
    }
}
