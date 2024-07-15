using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodWillApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Users",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Users",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "Users");
        }
    }
}
