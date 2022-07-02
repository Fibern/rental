using rental.DataTypes;

namespace rental.Stores
{
    public class CarStore
    {
        public Car Car;
    
        public void GenerateEmptyCar()
        {
            Car = new Car();
        }

    }
}
