using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHive.Server.Migrations.EventsDb
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsSoldOut = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventModelUserModel",
                columns: table => new
                {
                    EventUsersId = table.Column<int>(type: "int", nullable: false),
                    UserEventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModelUserModel", x => new { x.EventUsersId, x.UserEventsId });
                    table.ForeignKey(
                        name: "FK_EventModelUserModel_Events_UserEventsId",
                        column: x => x.UserEventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventModelUserModel_Users_EventUsersId",
                        column: x => x.EventUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "Date", "ImageUrl", "IsSoldOut", "Name", "Price", "Type", "Venue" },
                values: new object[,]
                {
                    { 1, 3000, new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img1.jpg", false, "Justin Bieber", 800, 1, "Malmö Arena" },
                    { 2, 22000, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img2.jpg", false, "Malmö FF - IFK Göteborg", 230, 0, "Eleda Stadion" },
                    { 3, 550, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img3.jpg", false, "Johan Glans Tour", 400, 3, "Palladium" },
                    { 4, 13000, new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img4.jpg", false, "Big Slap", 700, 2, "Pildammsparken" },
                    { 5, 60, new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img5.jpg", false, "Doris & Knäckebröderna", 100, 4, "Stadsbiblioteket Malmö" },
                    { 6, 26000, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img6.jpg", false, "Tom Jones", 800, 1, "Parken Copenhagen" },
                    { 7, 34, new DateTime(2023, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img7.jpg", false, "World Padel Tour", 40, 0, "Helsingborg" },
                    { 8, 26000, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img8.jpg", false, "Flashback Forever Live", 200, 3, "Globen" },
                    { 9, 300, new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img9.jpg", false, "Babblarna The Musical", 120, 4, "Malmö Live" },
                    { 10, 12000, new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/event/img10.jpg", false, "Sweden Rock", 500, 2, "Norje" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username" },
                values: new object[,]
                {
                    { 1, "user" },
                    { 2, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventModelUserModel_UserEventsId",
                table: "EventModelUserModel",
                column: "UserEventsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventModelUserModel");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
