using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sporganize.Migrations
{
    /// <inheritdoc />
    public partial class SecondModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "userAppointments");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "userTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "userTeams");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "userAppointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
