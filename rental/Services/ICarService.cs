using rental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Services
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCars();

        Task<List<Car>> GetAvailableCars();

        Task<Car> GetCarByLicensePlate(String licensePlate);

        Task<Car> CreateCar(Car car);

        Task<bool> DeleteCar(String licensePlate);
    }
}
