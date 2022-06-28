using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.DataTypes
{
    public class Rent
    {
        public DateTime Start { get; set; }
        public DateTime Expire { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public Rent(DateTime start, DateTime expire, int carId, int userId)
        {
            Start = start;
            Expire = expire;
            CarId = carId;
            UserId = userId;
        }
    }
}
