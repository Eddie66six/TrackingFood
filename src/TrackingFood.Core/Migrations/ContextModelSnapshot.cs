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

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasMaxLength(50);

                    b.HasKey("IdCustomer");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.DeliveryAddress", b =>
                {
                    b.Property<int>("IdDeliveryAddress")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(200);

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

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("IdMenu")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("IdMenu");

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

                    b.HasKey("IdOrder");

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

                    b.Property<int>("IdDeliveryAddress");

                    b.Property<int>("IdDeliveryman");

                    b.Property<int>("Position");

                    b.HasKey("IdQueue");

                    b.HasIndex("IdDeliveryAddress");

                    b.HasIndex("IdDeliveryman");

                    b.ToTable("Queues");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.QueueHistory", b =>
                {
                    b.Property<int>("IdQueueHistory")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<int>("IdDeliveryAddress");

                    b.Property<int>("IdDeliveryman");

                    b.Property<int>("Position");

                    b.Property<DateTime>("RequestDate");

                    b.HasKey("IdQueueHistory");

                    b.HasIndex("IdDeliveryAddress");

                    b.HasIndex("IdDeliveryman");

                    b.ToTable("QueueHistories");
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.DeliveryAddress", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.Customer", "Customer")
                        .WithMany("Adresses")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.MenuItem", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.Menu", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("IdMenu")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("TrackingFood.Core.Domain.Entities.DeliveryAddress", "DeliveryAddress")
                        .WithMany("Queues")
                        .HasForeignKey("IdDeliveryAddress")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackingFood.Core.Domain.Entities.Deliveryman", "Deliveryman")
                        .WithMany("Queues")
                        .HasForeignKey("IdDeliveryman")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackingFood.Core.Domain.Entities.QueueHistory", b =>
                {
                    b.HasOne("TrackingFood.Core.Domain.Entities.DeliveryAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("IdDeliveryAddress")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackingFood.Core.Domain.Entities.Deliveryman", "Deliveryman")
                        .WithMany()
                        .HasForeignKey("IdDeliveryman")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
