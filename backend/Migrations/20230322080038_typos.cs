using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class typos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "start",
                table: "PositionsEmployees",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "PositionsEmployees",
                newName: "End");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "PositionsEmployees",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "PositionsEmployees",
                newName: "end");
        }
    }
}
