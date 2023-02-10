using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoraunt.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionOfPositionsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenuPositions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Decription",
                table: "MenuPositions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decription",
                table: "MenuPositions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenuPositions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
