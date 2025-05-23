using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewProjectMca.Migrations
{
    /// <inheritdoc />
    public partial class admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_admin",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_admin", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_contact",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contact", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_booktrips",
                columns: table => new
                {
                    b_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trip_from = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trip_to = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passengers = table.Column<int>(type: "int", nullable: true),
                    trip_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_booktrips", x => x.b_id);
                    table.ForeignKey(
                        name: "FK_tbl_booktrips_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bus",
                columns: table => new
                {
                    b_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    b_from = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    b_to = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passengers = table.Column<int>(type: "int", nullable: true),
                    b_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bus", x => x.b_id);
                    table.ForeignKey(
                        name: "FK_tbl_bus_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_flight",
                columns: table => new
                {
                    f_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_from = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    f_to = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    f_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passengers = table.Column<int>(type: "int", nullable: true),
                    f_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_flight", x => x.f_id);
                    table.ForeignKey(
                        name: "FK_tbl_flight_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_train",
                columns: table => new
                {
                    t_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    t_from = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    t_to = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    t_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passengers = table.Column<int>(type: "int", nullable: true),
                    t_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_train", x => x.t_id);
                    table.ForeignKey(
                        name: "FK_tbl_train_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_booktrips_user_id",
                table: "tbl_booktrips",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bus_user_id",
                table: "tbl_bus",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_flight_user_id",
                table: "tbl_flight",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_train_user_id",
                table: "tbl_train",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_admin");

            migrationBuilder.DropTable(
                name: "tbl_booktrips");

            migrationBuilder.DropTable(
                name: "tbl_bus");

            migrationBuilder.DropTable(
                name: "tbl_contact");

            migrationBuilder.DropTable(
                name: "tbl_flight");

            migrationBuilder.DropTable(
                name: "tbl_train");

            migrationBuilder.DropTable(
                name: "tbl_user");
        }
    }
}
