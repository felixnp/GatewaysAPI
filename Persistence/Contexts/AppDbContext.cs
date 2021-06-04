using gatewayapi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace gatewayapi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<PeripheralDevice> PeripheralDevices { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Gateway>().HasKey(p => p.Id);
            builder.Entity<Gateway>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Gateway>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Gateway>().Property(p => p.IpAddress).IsRequired().HasMaxLength(15);

            // Memory Database is not a relational database so it does not enforce the foreign key constraints
            // Anyway, this is the correct way to specify the FK constraint  
            builder.Entity<Gateway>().HasMany(p => p.Devices).WithOne(p => p.Gateway).HasForeignKey(p => p.GatewayID);


            var id1 = "e0c653d1-248b-4877-b629-e9030dce6095";
            var id2 = "138c4789-ad19-47e2-9b84-8375caf0a792";
            var id3 = "9dbae714-b2e7-4d46-89cb-81ce52a28741";
            // Add some Gateways to the database
            builder.Entity<Gateway>().HasData
            (
                new Gateway { Id = id1, Name = "Gateway-1", IpAddress = "127.0.0.1"} , 
                new Gateway { Id = id2, Name = "Gateway-2", IpAddress = "192.168.0.1"},
                new Gateway { Id = id3, Name = "Gateway-3", IpAddress = "192.168.0.254"}
            );

            builder.Entity<PeripheralDevice>().HasKey(p => p.Uid);
            builder.Entity<PeripheralDevice>().Property(p => p.Uid).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PeripheralDevice>().Property(p => p.Vendor).IsRequired().HasMaxLength(50);
            builder.Entity<PeripheralDevice>().Property(p => p.DateCreated).IsRequired();
            builder.Entity<PeripheralDevice>().Property(p => p.Online).IsRequired();

            // Add some Peripherals to the database
            builder.Entity<PeripheralDevice>().HasData
             (
                 new PeripheralDevice
                 {
                     Uid = 10000,
                     Vendor = "Siemens",
                     DateCreated = new DateTime(2000, 10, 01),
                     Online = true,
                     GatewayID = id1
                 },
                 new PeripheralDevice
                 {
                     Uid = 10001,
                     Vendor = "Sony",
                     DateCreated = new DateTime(2010, 01, 01),
                     Online = true,
                     GatewayID = id1
                 },
                 new PeripheralDevice
                 {
                     Uid = 10002,
                     Vendor = "Sanyo",
                     DateCreated = new DateTime(2018, 02, 03),
                     Online = false,
                     GatewayID = id2
                 }
             );
        }
    }
}
