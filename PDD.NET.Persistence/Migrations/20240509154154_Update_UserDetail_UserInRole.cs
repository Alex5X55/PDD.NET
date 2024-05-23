using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDD.NET.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_UserDetail_UserInRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "UserDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "UserDetails");
        }
    }
}
