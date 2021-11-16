using Microsoft.EntityFrameworkCore.Migrations;

namespace BlingLeatherProductsLtd.Migrations
{
    public partial class chemical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChemicalMaterials",
                columns: table => new
                {
                    CMID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HSCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecievedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRecieved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BalancedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalMaterials", x => x.CMID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChemicalMaterials");
        }
    }
}
