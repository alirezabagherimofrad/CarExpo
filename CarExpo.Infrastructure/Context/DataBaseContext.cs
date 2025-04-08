
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarExpo.Domain.Models.CarBrands;

namespace CarExpo.Infrastructure.Context
{
    public class DataBaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }

        public DbSet<BahmanMotor> BahmanMotor { get; set; }

        public DbSet<Brilliance> Brilliance { get; set; }

        public DbSet<Chery> Chery { get; set; }

        public DbSet<Hyundai> Hyundaie { get; set; }

        public DbSet<JAC> Jac { get; set; }

        public DbSet<KermanMotor> KermanMotor { get; set; }

        public DbSet<Kia> Kia { get; set; }

        public DbSet<Lifan> Lifan { get; set; }

        public DbSet<ModiranKhodro> ModiranKhodro { get; set; }

        public DbSet<ParsKhodro> ParsKhodro { get; set; }

        public DbSet<Peugeot> Peugeot { get; set; }

        public DbSet<Renault> Renault { get; set; }

        public DbSet<Saipa> Saipa { get; set; }

        public DbSet<CarImage> CarImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>()
            .HasOne(c => c.User)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CarImage>()
           .HasOne(c => c.Car)
           .WithMany(c => c.CarImages)
           .HasForeignKey(c => c.CarId);

            modelBuilder.Entity<Car>()
           .Property(c => c.Mileage)
           .HasPrecision(18, 2); // یعنی 18 رقم عدد، 2 رقم اعشار


            modelBuilder.Entity<Car>().ToTable("Cars");

            modelBuilder.Entity<BahmanMotor>()
            .ToTable("BahmanMotor")
            .HasBaseType<Car>();

            modelBuilder.Entity<Brilliance>()
                .ToTable("Brilliance")
                .HasBaseType<Car>();

            modelBuilder.Entity<Chery>()
                .ToTable("Chery")
                .HasBaseType<Car>();

            modelBuilder.Entity<Hyundai>()
                .ToTable("Hyundai")
                .HasBaseType<Car>();

            modelBuilder.Entity<JAC>()
                .ToTable("JAC")
                .HasBaseType<Car>();

            modelBuilder.Entity<Kia>()
                .ToTable("Kia")
                .HasBaseType<Car>();

            modelBuilder.Entity<Lifan>()
                .ToTable("Lifan")
                .HasBaseType<Car>();

            modelBuilder.Entity<ModiranKhodro>()
                .ToTable("ModiranKhodro")
                .HasBaseType<Car>();

            modelBuilder.Entity<ParsKhodro>()
                .ToTable("ParsKhodro")
                .HasBaseType<Car>();

            modelBuilder.Entity<Peugeot>()
                .ToTable("Peugeot")
                .HasBaseType<Car>();

            modelBuilder.Entity<Renault>()
                .ToTable("Renault")
                .HasBaseType<Car>();

            modelBuilder.Entity<Saipa>()
                .ToTable("Saipa")
                .HasBaseType<Car>();
        }
    }
}





