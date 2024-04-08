using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rentacar.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marka = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    karoserija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gorivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zapreminaMotora = table.Column<int>(type: "int", nullable: false),
                    jacinaMotora = table.Column<int>(type: "int", nullable: false),
                    cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumKraja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bodovi = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    carId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bodovi = table.Column<int>(type: "int", nullable: false),
                    tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isLiked = table.Column<bool>(type: "bit", nullable: false),
                    isDisliked = table.Column<bool>(type: "bit", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    carId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Cars_carId",
                        column: x => x.carId,
                        principalTable: "Cars",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_carId",
                table: "Feedbacks",
                column: "carId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
