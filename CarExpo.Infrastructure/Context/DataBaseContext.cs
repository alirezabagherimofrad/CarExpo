
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarExpo.Domain.Models.Brands;
using CarExpo.Domain.Models.Orders;
using System.Security.Cryptography.Pkcs;
using CarExpo.Domain.Models.Payment;

namespace CarExpo.Infrastructure.Context
{
    public class DataBaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<Guid>>()
           .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<Guid>>()
            .HasKey(r => new { r.UserId, r.RoleId });

            modelBuilder.Entity<IdentityUserToken<Guid>>()
            .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = Guid.NewGuid(), Title = "Saipa" },
                new Brand { Id = Guid.NewGuid(), Title = "Kia" },
                new Brand { Id = Guid.NewGuid(), Title = "Peugeot" },
                new Brand { Id = Guid.NewGuid(), Title = "Hyundai" },
                new Brand { Id = Guid.NewGuid(), Title = "Chery" },
                new Brand { Id = Guid.NewGuid(), Title = "Brilliance" },
                new Brand { Id = Guid.NewGuid(), Title = "Renault" },
                new Brand { Id = Guid.NewGuid(), Title = "Lifan" },
                new Brand { Id = Guid.NewGuid(), Title = "JAC" },
                new Brand { Id = Guid.NewGuid(), Title = "BahmanMotor" },
                new Brand { Id = Guid.NewGuid(), Title = "ParsKhodro" },
                new Brand { Id = Guid.NewGuid(), Title = "ModiranKhodro" },
                new Brand { Id = Guid.NewGuid(), Title = "KermanMotor" }
            );

            modelBuilder.Entity<Car>()
            .Property(c => c.BrandId)
            .HasColumnType("uniqueidentifier");

            modelBuilder.Entity<Car>()
            .HasOne(c => c.Brand);
            //.WithMany(c=>c.Cars)
            //.HasForeignKey(c => c.BrandId)

            modelBuilder.Entity<Car>()
           .HasOne(c => c.User)
           .WithMany(c => c.Cars)
           .HasForeignKey(c => c.UserId);
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarImage>()
           .HasOne(c => c.Car)
           .WithMany(c => c.CarImages)
           .HasForeignKey(c => c.CarId);

            modelBuilder.Entity<Car>()
           .Property(c => c.Mileage)
           .HasPrecision(18, 2); // یعنی 18 رقم عدد، 2 رقم اعشار
        }
    }
}





