using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Repository.Db.Maps;
using System.IO;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using TrackingFood.Core.Domain;

namespace TrackingFood.Core.Repository.Db
{
    //primeira vez
    //Add-Migration InitialCreate -> Update-Database
    //atualizar
    //Add-Migration AddProductReviews -> Update-Database
    //remover
    //Remove-Migration
    //reverter
    //Update-Database LastGoodMigration
    public class Context : DbContext
    {
        private readonly Appsettings _appsettings;
        public Context(IOptions<Appsettings> appsettings)
        {
            _appsettings = appsettings.Value;
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<Deliveryman> Deliverymen { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<QueueHistory> QueueHistories { get; set; }
        public DbSet<Queue> Queues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Entity>();
            //modelBuilder.Ignore<Funcionario>();
            ////N:N
            //modelBuilder.Entity<ConvenioCredenciado>()
            //    .HasKey(t => new { t.IdMedico, t.IdConveio });
            //modelBuilder.Entity<ColaboradorPermissao>()
            //    .HasKey(t => new { t.IdColaborador, t.IdPermissao });

            ////geral
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new DeliveryAddressMap());
            modelBuilder.ApplyConfiguration(new DeliverymanMap());
            modelBuilder.ApplyConfiguration(new MenuItemMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new QueueHistoryMap());
            modelBuilder.ApplyConfiguration(new QueueMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // define the database to use
            optionsBuilder.UseSqlServer(_appsettings.ConnectionStrings.DefaultConnection);
        }
    }
}