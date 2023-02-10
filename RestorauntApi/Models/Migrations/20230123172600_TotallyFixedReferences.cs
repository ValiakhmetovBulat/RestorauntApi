using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoraunt.Migrations
{
    /// <inheritdoc />
    public partial class TotallyFixedReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_PositionTypes_PositionTypeId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_PositionTypeId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "PositionTypeId",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "PositionTypeId",
                table: "MenuPositions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuPositions_PositionTypeId",
                table: "MenuPositions",
                column: "PositionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPositions_PositionTypes_PositionTypeId",
                table: "MenuPositions",
                column: "PositionTypeId",
                principalTable: "PositionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPositions_PositionTypes_PositionTypeId",
                table: "MenuPositions");

            migrationBuilder.DropIndex(
                name: "IX_MenuPositions_PositionTypeId",
                table: "MenuPositions");

            migrationBuilder.DropColumn(
                name: "PositionTypeId",
                table: "MenuPositions");

            migrationBuilder.AddColumn<int>(
                name: "PositionTypeId",
                table: "Sections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PositionTypeId",
                table: "Sections",
                column: "PositionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_PositionTypes_PositionTypeId",
                table: "Sections",
                column: "PositionTypeId",
                principalTable: "PositionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
