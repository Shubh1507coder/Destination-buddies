using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewProjectMca.Migrations
{
    /// <inheritdoc />
    public partial class response : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ResponseStatus",
                table: "tbl_contact",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseStatus",
                table: "tbl_contact");
        }
    }
}
