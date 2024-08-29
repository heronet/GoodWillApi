using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodWillApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ManpowerRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ManpowerDonations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VolunteerCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ManpowerRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManpowerDonations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManpowerDonations_ManpowerRequests_ManpowerRequestId",
                        column: x => x.ManpowerRequestId,
                        principalTable: "ManpowerRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManpowerDonations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManpowerDonations_ManpowerRequestId",
                table: "ManpowerDonations",
                column: "ManpowerRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ManpowerDonations_UserId",
                table: "ManpowerDonations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManpowerDonations");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ManpowerRequests");
        }
    }
}
