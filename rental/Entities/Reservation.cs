using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Entities
{
    public class Reservation
    {
        public Reservation() { }
        public Reservation(User user, Car car, DateTime returnDate)
        {
            ReservationDate = DateTime.Now;
            ReturnDate = returnDate;
            User = user;
            Car = car;
            UpToDate = true;
        }

        [Key]
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }
        public bool UpToDate { get; set; }

        public bool IsUpToDate()
        {
            return ReturnDate.CompareTo(DateTime.Now) >= 0 && UpToDate;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        }
    }
}
