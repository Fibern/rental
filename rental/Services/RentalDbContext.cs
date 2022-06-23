using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rental.Resources.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Entities
{
    public class RentalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        public RentalDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Login).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Login).HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.FirstName).HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.LastName).HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.DateOfBirth).HasColumnType("date");
            modelBuilder.Entity<User>().Property(x => x.Balance).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<User>().Property(x => x.Balance).IsRequired();
            modelBuilder.Entity<User>().HasMany(x => x.Reservations).WithOne(y => y.User);

            modelBuilder.Entity<Car>().Property(x => x.LicensePlate).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.LicensePlate).HasColumnType("varchar(200)"); 
            modelBuilder.Entity<Car>().Property(x => x.Color).HasColumnType("varchar(200)"); 
            modelBuilder.Entity<Car>().Property(x => x.YearOfProduction).HasColumnType("smallint"); 
            modelBuilder.Entity<Car>().Property(x => x.FuelUsage).HasColumnType("double"); 
            modelBuilder.Entity<Car>().Property(x => x.CostPerDay).HasColumnType("decimal(10,2)"); 
            modelBuilder.Entity<Car>().Property(x => x.CostPerDay).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Fuel).HasConversion(new EnumToStringConverter<Fuel>());
            modelBuilder.Entity<Car>().Property(x => x.Fuel).HasColumnType("varchar(25)");
            modelBuilder.Entity<Car>().Property(x => x.Type).HasConversion(new EnumToStringConverter<CarType>());
            modelBuilder.Entity<Car>().Property(x => x.Type).HasColumnType("varchar(25)");
            modelBuilder.Entity<Car>().Property(x => x.Gearbox).HasConversion(new EnumToStringConverter<Gearbox>());
            modelBuilder.Entity<Car>().Property(x => x.Gearbox).HasColumnType("varchar(25)");
            modelBuilder.Entity<Car>().Property(x => x.AirConditioning).HasConversion(new EnumToStringConverter<AirConditioning>());
            modelBuilder.Entity<Car>().Property(x => x.AirConditioning).HasColumnType("varchar(25)");
            modelBuilder.Entity<Car>().HasMany(x => x.Reservations).WithOne(y => y.Car);

            modelBuilder.Entity<Reservation>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<Reservation>().Property(x => x.Id).HasColumnType("int");
            modelBuilder.Entity<Reservation>().Property(x => x.ReservationDate).HasColumnType("date");
            modelBuilder.Entity<Reservation>().Property(x => x.ReturnDate).HasColumnType("date");
            modelBuilder.Entity<Reservation>().Property(x => x.ReturnDate).HasColumnType("date");

            modelBuilder.Entity<Brand>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Brand>().Property(x => x.Name).HasColumnType("varchar(200)");
            modelBuilder.Entity<Brand>().HasMany(x => x.Cars).WithOne(y => y.Brand);

            modelBuilder.Entity<Model>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Model>().Property(x => x.Name).HasColumnType("varchar(200)");
            modelBuilder.Entity<Model>().Property(x => x.NumberOfSeats).HasColumnType("tinyint");
            modelBuilder.Entity<Model>().Property(x => x.Photo).HasColumnType("varchar(200)");
            modelBuilder.Entity<Model>().HasMany(x => x.Cars).WithOne(y => y.Model);











        }

    }
}
