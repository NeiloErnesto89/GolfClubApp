using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfClubApp.Migrations.Booking
{
    /// <inheritdoc />
    public partial class InitUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BookingTime",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumMembers",
                table: "Booking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingTime",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "NumMembers",
                table: "Booking");
        }
    }
}
