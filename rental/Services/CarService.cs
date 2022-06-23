using Microsoft.EntityFrameworkCore;
using rental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Services
{
    public class CarService : ICarService
    {
        private readonly RentalDbContextFactory _contextFactory;

        public CarService(RentalDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Car> CreateCar(Car car)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                var newCar = await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
                return newCar.Entity;
            }
        }

        public async Task<bool> DeleteCar(string licensePlate)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                Car car = await context.Cars.FirstOrDefaultAsync((c) => c.LicensePlate.Equals(licensePlate));
                if (car == null)
                {
                    throw new Exception("Car with license plate:" + licensePlate + " doesn't exist");
                }
                context.Cars.Remove(car);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Car>> GetAllCars()
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                List<Car> allCars = await context.Cars.ToListAsync();
                return allCars;
            }
        }

        public async Task<List<Car>> GetAvailableCars()
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                List<Car> availableCars =(await GetAllCars()).FindAll(e => e.availability()).ToList();
                return availableCars;
            }
        }

        public async Task<Car> GetCarByLicensePlate(string licensePlate)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                Car car = await context.Cars.FirstOrDefaultAsync((c) => c.LicensePlate.Equals(licensePlate));
                if (car == null)
                {
                    throw new Exception("Car with license plate:" + licensePlate + " doesn't exist");
                }
                return car;
            }
        }
    }
}
