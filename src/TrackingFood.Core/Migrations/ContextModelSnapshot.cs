﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Company", b =>
                {
                    b.Property<int>("IdCompany")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("IdCompany");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.CompanyBranch", b =>
                {
                    b.Property<int>("IdCompanyBranch")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCompany");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("IdCompanyBranch");

                    b.HasIndex("IdCompany");

                    b.ToTable("CompanyBranches");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Credencial", b =>
                {
                    b.Property<int>("IdCredencial")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasMaxLength(21);

                    b.HasKey("IdCredencial");

                    b.ToTable("Credencials");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentNumber");

                    b.Property<int>("IdCredencial");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("IdCustomer");

                    b.HasIndex("IdCredencial")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.DeliveryAddress", b =>
                {
                    b.Property<int>("IdDeliveryAddress")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("City");

                    b.Property<string>("FullNumber")
                        .HasMaxLength(50);

                    b.Property<int>("IdCustomer");

                    b.HasKey("IdDeliveryAddress");

                    b.HasIndex("IdCustomer");

                    b.ToTable("DeliveryAddresses");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Deliveryman", b =>
                {
                    b.Property<int>("IdDeliveryman")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("IdDeliveryman");

                    b.ToTable("Deliverymen");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCompanyBranch");

                    b.Property<int>("IdCredencial");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("IdEmployee");

                    b.HasIndex("IdCompanyBranch");

                    b.HasIndex("IdCredencial")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("IdMenu")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCompanyBranch");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("IdMenu");

                    b.HasIndex("IdCompanyBranch");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.MenuItem", b =>
                {
                    b.Property<int>("IdMenuItens")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<int>("IdMenu");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("UrlImage")
                        .HasMaxLength(1000);

                    b.Property<decimal>("Value");

                    b.HasKey("IdMenuItens");

                    b.HasIndex("IdMenu");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DeliveryValue");

                    b.Property<int>("IdCompanyBranch");

                    b.HasKey("IdOrder");

                    b.HasIndex("IdCompanyBranch");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("IdOrderItem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("IdMenuItem");

                    b.Property<int?>("MenuItemIdMenuItens");

                    b.Property<int?>("OrderIdOrder");

                    b.HasKey("IdOrderItem");

                    b.HasIndex("MenuItemIdMenuItens");

                    b.HasIndex("OrderIdOrder");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Queue", b =>
                {
                    b.Property<int>("IdQueue")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCompanyBranch");

                    b.Property<int>("IdDeliveryAddress");

                    b.Property<int>("IdDeliveryman");

                    b.Property<int>("IdOrder");

                    b.Property<int>("Position");

                    b.HasKey("IdQueue");

                    b.HasIndex("IdCompanyBranch");

                    b.HasIndex("IdDeliveryAddress");

                    b.HasIndex("IdDeliveryman");

                    b.HasIndex("IdOrder")
                        .IsUnique();

                    b.ToTable("Queues");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.QueueHistory", b =>
                {
                    b.Property<int>("IdQueueHistory")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<int>("IdCompanyBranch");

                    b.Property<int>("IdDeliveryAddress");

                    b.Property<int>("IdDeliveryman");

                    b.Property<int>("IdOrder");

                    b.Property<int>("Position");

                    b.Property<DateTime>("RequestDate");

                    b.HasKey("IdQueueHistory");

                    b.HasIndex("IdCompanyBranch");

                    b.HasIndex("IdDeliveryAddress");

                    b.HasIndex("IdDeliveryman");

                    b.HasIndex("IdOrder")
                        .IsUnique();

                    b.ToTable("QueueHistories");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.CompanyBranch", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.Company", "Company")
                        .WithMany("CompanyBranches")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Customer", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.Credencial", "Credencial")
                        .WithOne("Customer")
                        .HasForeignKey("TrackingFood.Core.Domain.Entities.Customer", "IdCredencial")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.DeliveryAddress", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.Customer", "Customer")
                        .WithMany("Adresses")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Employee", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.CompanyBranch", "CompanyBranch")
                        .WithMany("Employees")
                        .HasForeignKey("IdCompanyBranch")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TrackingFood.Core.Domain.Entities.Credencial", "Credencial")
                        .WithOne("Employee")
                        .HasForeignKey("TrackingFood.Core.Domain.Entities.Employee", "IdCredencial")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Menu", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.CompanyBranch", "CompanyBranch")
                        .WithMany("Menus")
                        .HasForeignKey("IdCompanyBranch")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.MenuItem", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.Menu", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("IdMenu")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Order", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.CompanyBranch", "CompanyBranch")
                        .WithMany("Orders")
                        .HasForeignKey("IdCompanyBranch")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuItemIdMenuItens");

                    b.HasOne("TrackingFood.Core.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderIdOrder");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Queue", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.CompanyBranch", "CompanyBranch")
                        .WithMany("Queues")
                        .HasForeignKey("IdCompanyBranch")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TrackingFood.Core.Domain.Entities.DeliveryAddress", "DeliveryAddress")
                        .WithMany("Queues")
                        .HasForeignKey("IdDeliveryAddress")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackingFood.Core.Domain.Entities.Deliveryman", "Deliveryman")
                        .WithMany("Queues")
                        .HasForeignKey("IdDeliveryman")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackingFood.Core.Domain.Entities.Order", "Order")
                        .WithOne("Queue")
                        .HasForeignKey("TrackingFood.Core.Domain.Entities.Queue", "IdOrder")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.QueueHistory", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.CompanyBranch", "CompanyBranch")
                        .WithMany("QueueHistories")
                        .HasForeignKey("IdCompanyBranch")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TrackingFood.Core.Domain.Entities.DeliveryAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("IdDeliveryAddress")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackingFood.Core.Domain.Entities.Deliveryman", "Deliveryman")
                        .WithMany()
                        .HasForeignKey("IdDeliveryman")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackingFood.Core.Domain.Entities.Order", "Order")
                        .WithOne("QueueHistory")
                        .HasForeignKey("TrackingFood.Core.Domain.Entities.QueueHistory", "IdOrder")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
