using System.Text.Json.Serialization;

namespace rental.DataTypes
{
    public class Car
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int EngineCapacity { get; set; }
        public string FuelType { get; set; }
        public int HorsePower { get; set; }
        public string Transmission { get; set; }
        public string Drive { get; set; }
        public double FuelUsage { get; set; }
        public string BodyStyle { get; set; }
        public int Seats { get; set; }
        public string Colour { get; set; }
        public bool IsRented { get; set; }
        public string Image { get; set; }

        [JsonIgnore]
        public string Name { get => Brand + " " + Model; }
        [JsonIgnore]
        public string DPrice { get => Price.ToString() + " zł/dzień"; }

        public Car()        {
            Id = 0;
            Price = 0;
            Brand = "";
            Model = "";
            Year = 0;
            EngineCapacity = 0;
            FuelType = "";
            HorsePower = 0;
            Transmission = "";
            Drive = "";
            FuelUsage = 0;
            BodyStyle = "";
            Seats = 0;
            Colour = "";
            IsRented = false;
            Image = "";
        }

        public Car(int id, decimal price, string brand, string model,
            int year, int engineCapacity, string fuelType, int horsePower,
            string transmission, string drive, double fuelUsage, string bodyStyle,
            int seats, string colour, bool isRented, string image)
        {
            Id = id;
            Price = price;
            Brand = brand;
            Model = model;
            Year = year;
            EngineCapacity = engineCapacity;
            FuelType = fuelType;
            HorsePower = horsePower;
            Transmission = transmission;
            Drive = drive;
            FuelUsage = fuelUsage;
            BodyStyle = bodyStyle;
            Seats = seats;
            Colour = colour;
            IsRented = isRented;
            Image = image;  
        }
    }
}
