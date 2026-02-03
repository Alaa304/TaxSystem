using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplyBaseEntityToAllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogID",
                table: "SystemLogs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OfficeID",
                table: "Offices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ArchivedID",
                table: "Archives",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmployeeRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeRoles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SystemLogs",
                newName: "LogID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Offices",
                newName: "OfficeID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Archives",
                newName: "ArchivedID");
        }
    }
}
