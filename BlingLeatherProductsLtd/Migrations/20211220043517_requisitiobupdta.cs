using Microsoft.EntityFrameworkCore.Migrations;

namespace BlingLeatherProductsLtd.Migrations
{
    public partial class requisitiobupdta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ARID",
                table: "RequisitionAccessories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ARID",
                table: "RequisitionAccessories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
