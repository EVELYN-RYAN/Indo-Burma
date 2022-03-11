using Microsoft.EntityFrameworkCore.Migrations;

namespace Indo_Burma.Migrations
{
    public partial class AddFulfilled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderFulfilled",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderFulfilled",
                table: "Orders");
        }
    }
}
