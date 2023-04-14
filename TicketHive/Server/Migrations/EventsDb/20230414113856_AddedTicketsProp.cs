using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHive.Server.Migrations.EventsDb
{
    /// <inheritdoc />
    public partial class AddedTicketsProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSoldOut",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "TicketsSold",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "TicketsSold",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "TicketsSold",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "TicketsSold",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "TicketsSold",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "TicketsSold",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "TicketsSold",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                column: "TicketsSold",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                column: "TicketsSold",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9,
                column: "TicketsSold",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                column: "TicketsSold",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsSold",
                table: "Events");

            migrationBuilder.AddColumn<bool>(
                name: "IsSoldOut",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsSoldOut",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsSoldOut",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsSoldOut",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsSoldOut",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsSoldOut",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsSoldOut",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsSoldOut",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsSoldOut",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsSoldOut",
                value: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsSoldOut",
                value: false);
        }
    }
}
