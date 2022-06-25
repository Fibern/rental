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
        public Car Car { get; set; } 
    }
}
