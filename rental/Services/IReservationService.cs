using rental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Services
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllReservations();

        Task<List<Reservation>> GetAvailableReservations();

        Task<Reservation> GetReservationById(int id);

        Task<Reservation> CreateReservation(String userLogin, String carLicensePlate, int period);

        Task<bool> DeleteReservation(int id);
    }
}
