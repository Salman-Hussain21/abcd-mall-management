using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC_mall.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CinemaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CinemaLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CinemaSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodCourtModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodCourtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodCourtLogo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCourtModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShopsModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopLogo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopsModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movies_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Movies_Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ScreeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cinema_ID = table.Column<int>(type: "int", nullable: false),
                    MoviePicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_MoviesModel_CinemaModel_Cinema_ID",
                        column: x => x.Cinema_ID,
                        principalTable: "CinemaModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookedSeats",
                columns: table => new
                {
                    BookedSeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedSeats", x => x.BookedSeatId);
                    table.ForeignKey(
                        name: "FK_BookedSeats_CinemaModel_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "CinemaModel",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_BookedSeats_MoviesModel_MovieID",
                        column: x => x.MovieID,
                        principalTable: "MoviesModel",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedSeats_CinemaId",
                table: "BookedSeats",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedSeats_MovieID",
                table: "BookedSeats",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesModel_Cinema_ID",
                table: "MoviesModel",
                column: "Cinema_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedSeats");

            migrationBuilder.DropTable(
                name: "ContactTable");

            migrationBuilder.DropTable(
                name: "FeedbackTable");

            migrationBuilder.DropTable(
                name: "FoodCourtModel");

            migrationBuilder.DropTable(
                name: "ProductModel");

            migrationBuilder.DropTable(
                name: "RegisterModel");

            migrationBuilder.DropTable(
                name: "ShopsModel");

            migrationBuilder.DropTable(
                name: "MoviesModel");

            migrationBuilder.DropTable(
                name: "CinemaModel");
        }
    }
}
