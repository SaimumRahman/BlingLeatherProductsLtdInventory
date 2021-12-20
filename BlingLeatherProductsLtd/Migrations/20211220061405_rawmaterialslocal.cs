using Microsoft.EntityFrameworkCore.Migrations;

namespace BlingLeatherProductsLtd.Migrations
{
    public partial class rawmaterialslocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawMaterialsDetailsLocal",
                columns: table => new
                {
                    RMDIDL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RMIDL = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BalanceQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequisitionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionOrDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialsDetailsLocal", x => x.RMDIDL);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialsLocal",
                columns: table => new
                {
                    RMIDL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChalanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecievedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRecieved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BalancedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialsLocal", x => x.RMIDL);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawMaterialsDetailsLocal");

            migrationBuilder.DropTable(
                name: "RawMaterialsLocal");
        }
    }
}
