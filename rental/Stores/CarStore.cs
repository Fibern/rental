using rental.Model;

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
