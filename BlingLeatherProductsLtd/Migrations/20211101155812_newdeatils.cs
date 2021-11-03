using Microsoft.EntityFrameworkCore.Migrations;

namespace BlingLeatherProductsLtd.Migrations
{
    public partial class newdeatils : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawMaterialsDetails",
                columns: table => new
                {
                    RMDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RMID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChalanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeforeQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecievedeQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BalanceQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequisitionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionOrDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialsDetails", x => x.RMDID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawMaterialsDetails");
        }
    }
}
