using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.DataTypes
{
    public class Car
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public bool IsRented { get; set; }
        public Car(int id, decimal price, string name, bool isRented)
        {
            Id = id;
            Price = price;
            Name = name;
            IsRented = isRented;
        }
    }
}
