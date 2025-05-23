using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewProjectMca.Migrations
{
    /// <inheritdoc />
    public partial class @as : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "paymentId",
                table: "tbl_bus",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "tbl_bus");
        }
    }
}
