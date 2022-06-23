using Newtonsoft.Json;
using rental.Resources.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public short YearOfProduction { get; set; }
        public double FuelUsage { get; set; }
        public decimal CostPerDay { get; set; }
        public Brand Brand { get; set; } 
        public Model Model { get; set; }
        internal Fuel Fuel { get; set; }
        internal CarType Type { get; set; }
        internal Gearbox Gearbox { get; set; }
        internal AirConditioning AirConditioning { get; set; }
        public List<Reservation> Reservations { get; set; }

        public bool availability()
        {
            return Reservations.FindAll(e => e.IsUpToDate()).ToList().Count() == 0;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        }
    }
}
