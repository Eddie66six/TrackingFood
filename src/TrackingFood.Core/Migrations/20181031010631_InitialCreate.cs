using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingFood.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Deliverymen",
                columns: table => new
                {
                    IdDeliveryman = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverymen", x => x.IdDeliveryman);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    IdMenu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.IdMenu);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeliveryValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddresses",
                columns: table => new
                {
                    IdDeliveryAddress = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    FullNumber = table.Column<string>(maxLength: 50, nullable: true),
                    IdCustomer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddresses", x => x.IdDeliveryAddress);
                    table.ForeignKey(
                        name: "FK_DeliveryAddresses_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    IdMenuItens = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    UrlImage = table.Column<string>(maxLength: 1000, nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    IdMenu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.IdMenuItens);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_IdMenu",
                        column: x => x.IdMenu,
                        principalTable: "Menus",
                        principalColumn: "IdMenu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueueHistories",
                columns: table => new
                {
                    IdQueueHistory = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Position = table.Column<int>(nullable: false),
                    IdDeliveryAddress = table.Column<int>(nullable: false),
                    IdDeliveryman = table.Column<int>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueHistories", x => x.IdQueueHistory);
                    table.ForeignKey(
                        name: "FK_QueueHistories_DeliveryAddresses_IdDeliveryAddress",
                        column: x => x.IdDeliveryAddress,
                        principalTable: "DeliveryAddresses",
                        principalColumn: "IdDeliveryAddress",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QueueHistories_Deliverymen_IdDeliveryman",
                        column: x => x.IdDeliveryman,
                        principalTable: "Deliverymen",
                        principalColumn: "IdDeliveryman",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queues",
                columns: table => new
                {
                    IdQueue = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Position = table.Column<int>(nullable: false),
                    IdDeliveryAddress = table.Column<int>(nullable: false),
                    IdDeliveryman = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.IdQueue);
                    table.ForeignKey(
                        name: "FK_Queues_DeliveryAddresses_IdDeliveryAddress",
                        column: x => x.IdDeliveryAddress,
                        principalTable: "DeliveryAddresses",
                        principalColumn: "IdDeliveryAddress",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Queues_Deliverymen_IdDeliveryman",
                        column: x => x.IdDeliveryman,
                        principalTable: "Deliverymen",
                        principalColumn: "IdDeliveryman",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    IdOrderItem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdMenuItem = table.Column<int>(nullable: false),
                    MenuItemIdMenuItens = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    OrderIdOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.IdOrderItem);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemIdMenuItens",
                        column: x => x.MenuItemIdMenuItens,
                        principalTable: "MenuItems",
                        principalColumn: "IdMenuItens",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddresses_IdCustomer",
                table: "DeliveryAddresses",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_IdMenu",
                table: "MenuItems",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemIdMenuItens",
                table: "OrderItems",
                column: "MenuItemIdMenuItens");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderIdOrder",
                table: "OrderItems",
                column: "OrderIdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_QueueHistories_IdDeliveryAddress",
                table: "QueueHistories",
                column: "IdDeliveryAddress");

            migrationBuilder.CreateIndex(
                name: "IX_QueueHistories_IdDeliveryman",
                table: "QueueHistories",
                column: "IdDeliveryman");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_IdDeliveryAddress",
                table: "Queues",
                column: "IdDeliveryAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_IdDeliveryman",
                table: "Queues",
                column: "IdDeliveryman");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "QueueHistories");

            migrationBuilder.DropTable(
                name: "Queues");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryAddresses");

            migrationBuilder.DropTable(
                name: "Deliverymen");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
