using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlibabaClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDatabaseAfterFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_Locations_LocationId",
                table: "Transportations");

            migrationBuilder.DropIndex(
                name: "IX_Transportations_LocationId",
                table: "Transportations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Transportations");

            migrationBuilder.AlterDatabase(
                collation: "Persian_100_CI_AI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                oldCollation: "Persian_100_CI_AI");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Transportations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_LocationId",
                table: "Transportations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_Locations_LocationId",
                table: "Transportations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
