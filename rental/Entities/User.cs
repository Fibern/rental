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
    public class User
    {   
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }

        public List<Reservation> Reservations { get; set; }

        public void BalanceAfterReservation(int period, decimal costPerDay)
        {
            Balance -= period * costPerDay;
        }

        public void BalanceBeforeReservation(int period, decimal costPerDay)
        {
            Balance -= period * costPerDay;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        }
    }
}
