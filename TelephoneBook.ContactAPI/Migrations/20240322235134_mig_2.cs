using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelephoneBook.ContactAPI.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InformationType",
                table: "ContactInfo");

            migrationBuilder.AddColumn<string>(
                name: "EMailAddress",
                table: "ContactInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ContactInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ContactInfo",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMailAddress",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ContactInfo");

            migrationBuilder.AddColumn<int>(
                name: "InformationType",
                table: "ContactInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
