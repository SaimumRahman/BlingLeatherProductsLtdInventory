using Microsoft.EntityFrameworkCore.Migrations;

namespace BlingLeatherProductsLtd.Migrations
{
    public partial class usertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "StoreLogins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "StoreLogins");
        }
    }
}
