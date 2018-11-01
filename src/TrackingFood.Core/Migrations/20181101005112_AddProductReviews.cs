using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingFood.Core.Migrations
{
    public partial class AddProductReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCompanyBranch",
                table: "Queues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdOrder",
                table: "Queues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompanyBranch",
                table: "QueueHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdOrder",
                table: "QueueHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompanyBranch",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompanyBranch",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdCompany = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdCompany);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBranches",
                columns: table => new
                {
                    IdCompanyBranch = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    IdCompany = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranches", x => x.IdCompanyBranch);
                    table.ForeignKey(
                        name: "FK_CompanyBranches_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdCompany",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Queues_IdCompanyBranch",
                table: "Queues",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_IdOrder",
                table: "Queues",
                column: "IdOrder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QueueHistories_IdCompanyBranch",
                table: "QueueHistories",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_QueueHistories_IdOrder",
                table: "QueueHistories",
                column: "IdOrder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCompanyBranch",
                table: "Orders",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_IdCompanyBranch",
                table: "Menus",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranches_IdCompany",
                table: "CompanyBranches",
                column: "IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_CompanyBranches_IdCompanyBranch",
                table: "Menus",
                column: "IdCompanyBranch",
                principalTable: "CompanyBranches",
                principalColumn: "IdCompanyBranch",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CompanyBranches_IdCompanyBranch",
                table: "Orders",
                column: "IdCompanyBranch",
                principalTable: "CompanyBranches",
                principalColumn: "IdCompanyBranch",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QueueHistories_CompanyBranches_IdCompanyBranch",
                table: "QueueHistories",
                column: "IdCompanyBranch",
                principalTable: "CompanyBranches",
                principalColumn: "IdCompanyBranch",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QueueHistories_Orders_IdOrder",
                table: "QueueHistories",
                column: "IdOrder",
                principalTable: "Orders",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Queues_CompanyBranches_IdCompanyBranch",
                table: "Queues",
                column: "IdCompanyBranch",
                principalTable: "CompanyBranches",
                principalColumn: "IdCompanyBranch",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Queues_Orders_IdOrder",
                table: "Queues",
                column: "IdOrder",
                principalTable: "Orders",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_CompanyBranches_IdCompanyBranch",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CompanyBranches_IdCompanyBranch",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_QueueHistories_CompanyBranches_IdCompanyBranch",
                table: "QueueHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_QueueHistories_Orders_IdOrder",
                table: "QueueHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Queues_CompanyBranches_IdCompanyBranch",
                table: "Queues");

            migrationBuilder.DropForeignKey(
                name: "FK_Queues_Orders_IdOrder",
                table: "Queues");

            migrationBuilder.DropTable(
                name: "CompanyBranches");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Queues_IdCompanyBranch",
                table: "Queues");

            migrationBuilder.DropIndex(
                name: "IX_Queues_IdOrder",
                table: "Queues");

            migrationBuilder.DropIndex(
                name: "IX_QueueHistories_IdCompanyBranch",
                table: "QueueHistories");

            migrationBuilder.DropIndex(
                name: "IX_QueueHistories_IdOrder",
                table: "QueueHistories");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdCompanyBranch",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Menus_IdCompanyBranch",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IdCompanyBranch",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "IdOrder",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "IdCompanyBranch",
                table: "QueueHistories");

            migrationBuilder.DropColumn(
                name: "IdOrder",
                table: "QueueHistories");

            migrationBuilder.DropColumn(
                name: "IdCompanyBranch",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdCompanyBranch",
                table: "Menus");
        }
    }
}
