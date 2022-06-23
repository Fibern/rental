using Microsoft.EntityFrameworkCore;
using rental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Services
{
    public class ReservationService : IReservationService
    {
        private readonly RentalDbContextFactory _contextFactory;

        public ReservationService(RentalDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Reservation> CreateReservation(string userLogin, string carLicensePlate, int period)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                User user = await context.Users.FirstOrDefaultAsync((u) => u.Login.Equals(userLogin));
                Car car = await context.Cars.FirstOrDefaultAsync((c) => c.LicensePlate.Equals(carLicensePlate));
                if(user == null)
                {
                    throw new Exception("User with login:" + userLogin + " doesn't exist");
                }
                if (car == null)
                {
                    throw new Exception("Car with license plate:" + carLicensePlate + " doesn't exist");
                }
                if (car.availability())
                {
                    if(period * car.CostPerDay <= user.Balance)
                    {
                        Reservation reservation = new Reservation(user, car, DateTime.Now.AddDays(period));
                        user.BalanceAfterReservation(period, car.CostPerDay);
                        var newReservation = await context.Reservations.AddAsync(reservation);
                        await context.SaveChangesAsync();
                        return newReservation.Entity;
                    }
                    else
                    {
                        throw new Exception("User cannot afford this reservation");
                    }
                }
                else
                {
                    throw new Exception("This car isn't available");
                }

            }
        }

        public async Task<bool> DeleteReservation(int id)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                Reservation reservation = await context.Reservations.FirstOrDefaultAsync((c) => c.Id == id);
                if (reservation == null)
                {
                    throw new Exception("Reservation with id:" + id + " doesn't exist");
                }
                reservation.User.BalanceBeforeReservation((int)(reservation.ReturnDate - DateTime.Now).TotalDays, reservation.Car.CostPerDay);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                List<Reservation> allReservations = await context.Reservations.ToListAsync();
                return allReservations;
            }
        }

        public async Task<List<Reservation>> GetAvailableReservations()
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                List<Reservation> availableReservations = (await GetAllReservations()).FindAll(e => e.IsUpToDate()).ToList();
                return availableReservations;
            }
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                Reservation reservation = await context.Reservations.FirstOrDefaultAsync((c) => c.Id == id);
                if (reservation == null)
                {
                    throw new Exception("Reservation with id:" + id + " doesn't exist");
                }
                return reservation;
            }
        }
    }
}
