using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingFood.Core.Migrations
{
    public partial class AddProductReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    IdCompanyBranch = table.Column<int>(nullable: false),
                    IdCredencial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employees_CompanyBranches_IdCompanyBranch",
                        column: x => x.IdCompanyBranch,
                        principalTable: "CompanyBranches",
                        principalColumn: "IdCompanyBranch",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Credencials_IdCredencial",
                        column: x => x.IdCredencial,
                        principalTable: "Credencials",
                        principalColumn: "IdCredencial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdCompanyBranch",
                table: "Employees",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdCredencial",
                table: "Employees",
                column: "IdCredencial",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
