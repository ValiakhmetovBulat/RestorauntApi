using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoraunt.Migrations
{
    /// <inheritdoc />
    public partial class FixedReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPositions_PositionTypes_PositionTypeId",
                table: "MenuPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionTypes_Sections_SectionId",
                table: "PositionTypes");

            migrationBuilder.DropIndex(
                name: "IX_PositionTypes_SectionId",
                table: "PositionTypes");

            migrationBuilder.DropIndex(
                name: "IX_MenuPositions_PositionTypeId",
                table: "MenuPositions");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "PositionTypes");

            migrationBuilder.DropColumn(
                name: "PositionTypeId",
                table: "MenuPositions");

            migrationBuilder.AddColumn<int>(
                name: "PositionTypeId",
                table: "Sections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "MenuPositions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PositionTypeId",
                table: "Sections",
                column: "PositionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPositions_SectionId",
                table: "MenuPositions",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPositions_Sections_SectionId",
                table: "MenuPositions",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_PositionTypes_PositionTypeId",
                table: "Sections",
                column: "PositionTypeId",
                principalTable: "PositionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPositions_Sections_SectionId",
                table: "MenuPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_PositionTypes_PositionTypeId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_PositionTypeId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_MenuPositions_SectionId",
                table: "MenuPositions");

            migrationBuilder.DropColumn(
                name: "PositionTypeId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "MenuPositions");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "PositionTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionTypeId",
                table: "MenuPositions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PositionTypes_SectionId",
                table: "PositionTypes",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPositions_PositionTypeId",
                table: "MenuPositions",
                column: "PositionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPositions_PositionTypes_PositionTypeId",
                table: "MenuPositions",
                column: "PositionTypeId",
                principalTable: "PositionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionTypes_Sections_SectionId",
                table: "PositionTypes",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");
        }
    }
}
