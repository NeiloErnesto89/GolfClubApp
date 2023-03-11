using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfClubApp.Migrations.Booking
{
    /// <inheritdoc />
    public partial class Update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumMembers",
                table: "Booking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumMembers",
                table: "Booking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
