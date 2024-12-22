using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC_mall.Migrations
{
    /// <inheritdoc />
    public partial class nm13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "BookedSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "BookedSeats");
        }
    }
}
