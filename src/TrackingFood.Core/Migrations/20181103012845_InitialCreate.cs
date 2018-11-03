﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingFood.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Credencials",
                columns: table => new
                {
                    IdCredencial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 21, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credencials", x => x.IdCredencial);
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

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    DocumentNumber = table.Column<string>(nullable: true),
                    IdCredencial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                    table.ForeignKey(
                        name: "FK_Customers_Credencials_IdCredencial",
                        column: x => x.IdCredencial,
                        principalTable: "Credencials",
                        principalColumn: "IdCredencial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    IdMenu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    IdCompanyBranch = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.IdMenu);
                    table.ForeignKey(
                        name: "FK_Menus_CompanyBranches_IdCompanyBranch",
                        column: x => x.IdCompanyBranch,
                        principalTable: "CompanyBranches",
                        principalColumn: "IdCompanyBranch",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeliveryValue = table.Column<decimal>(nullable: false),
                    IdCompanyBranch = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_CompanyBranches_IdCompanyBranch",
                        column: x => x.IdCompanyBranch,
                        principalTable: "CompanyBranches",
                        principalColumn: "IdCompanyBranch",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddresses",
                columns: table => new
                {
                    IdDeliveryAddress = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
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
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    IdOrder = table.Column<int>(nullable: false),
                    IdCompanyBranch = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueHistories", x => x.IdQueueHistory);
                    table.ForeignKey(
                        name: "FK_QueueHistories_CompanyBranches_IdCompanyBranch",
                        column: x => x.IdCompanyBranch,
                        principalTable: "CompanyBranches",
                        principalColumn: "IdCompanyBranch",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_QueueHistories_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
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
                    IdDeliveryman = table.Column<int>(nullable: false),
                    IdOrder = table.Column<int>(nullable: false),
                    IdCompanyBranch = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.IdQueue);
                    table.ForeignKey(
                        name: "FK_Queues_CompanyBranches_IdCompanyBranch",
                        column: x => x.IdCompanyBranch,
                        principalTable: "CompanyBranches",
                        principalColumn: "IdCompanyBranch",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Queues_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
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
                name: "IX_CompanyBranches_IdCompany",
                table: "CompanyBranches",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdCredencial",
                table: "Customers",
                column: "IdCredencial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddresses_IdCustomer",
                table: "DeliveryAddresses",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_IdMenu",
                table: "MenuItems",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_IdCompanyBranch",
                table: "Menus",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemIdMenuItens",
                table: "OrderItems",
                column: "MenuItemIdMenuItens");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderIdOrder",
                table: "OrderItems",
                column: "OrderIdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCompanyBranch",
                table: "Orders",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_QueueHistories_IdCompanyBranch",
                table: "QueueHistories",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_QueueHistories_IdDeliveryAddress",
                table: "QueueHistories",
                column: "IdDeliveryAddress");

            migrationBuilder.CreateIndex(
                name: "IX_QueueHistories_IdDeliveryman",
                table: "QueueHistories",
                column: "IdDeliveryman");

            migrationBuilder.CreateIndex(
                name: "IX_QueueHistories_IdOrder",
                table: "QueueHistories",
                column: "IdOrder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Queues_IdCompanyBranch",
                table: "Queues",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_IdDeliveryAddress",
                table: "Queues",
                column: "IdDeliveryAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_IdDeliveryman",
                table: "Queues",
                column: "IdDeliveryman");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_IdOrder",
                table: "Queues",
                column: "IdOrder",
                unique: true);
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
                name: "DeliveryAddresses");

            migrationBuilder.DropTable(
                name: "Deliverymen");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CompanyBranches");

            migrationBuilder.DropTable(
                name: "Credencials");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}