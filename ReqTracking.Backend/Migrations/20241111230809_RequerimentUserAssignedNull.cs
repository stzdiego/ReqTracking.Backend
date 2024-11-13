using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReqTracking.Backend.Migrations
{
    /// <inheritdoc />
    public partial class RequerimentUserAssignedNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requeriments_Users_UserAssignedId",
                table: "Requeriments");

            migrationBuilder.AlterColumn<int>(
                name: "UserAssignedId",
                table: "Requeriments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Requeriments_Users_UserAssignedId",
                table: "Requeriments",
                column: "UserAssignedId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requeriments_Users_UserAssignedId",
                table: "Requeriments");

            migrationBuilder.AlterColumn<int>(
                name: "UserAssignedId",
                table: "Requeriments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requeriments_Users_UserAssignedId",
                table: "Requeriments",
                column: "UserAssignedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
