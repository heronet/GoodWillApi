using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodWillApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManpowerType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IncidentType",
                table: "ManpowerRequests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncidentType",
                table: "ManpowerRequests");
        }
    }
}
