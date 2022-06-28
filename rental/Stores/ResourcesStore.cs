using Caliburn.Micro;
using rental.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Stores
{
    public static class ResourcesStore
    {
        private static string _path = "../../../Resources/";
        public static List<User> Users {
            get => Serializer<List<User>>.Deserialize(_path + "users.Json");
            set => Serializer<List<User>>.Serialize(value, _path + "users.Json");
        }

        public static List<Car> Cars {
            get => Serializer<List<Car>>.Deserialize(_path + "cars.Json");
            set => Serializer<List<Car>>.Serialize(value, _path + "cars.Json");
        }

        public static List<Rent> Rents
        {
            get => UpdateRents();
            set => Serializer<List<Rent>>.Serialize(value, _path + "rent.Json");
        }

        public static BindableCollection<Car> GetAvaliableCars()
        {
            BindableCollection<Car> cars = new BindableCollection<Car>();
            foreach (Car car in Cars)
                if (!car.IsRented)
                    cars.Add(car);
            return cars;
        }

        private static List<Rent> UpdateRents()
        {
            List<Rent> result = Serializer<List<Rent>>.Deserialize(_path + "rent.Json");
            List<Rent> returns = new List<Rent>();
            foreach (var item in result)
            {
                if (item.Expire <= DateTime.Now)
                {
                    returns.Add(item);
                    ChangeCarStatus(item.CarId);
                }
            }
            foreach(var item in returns)
                result.Remove(item);
            Rents = result;
            return result;
        }

        public static void ReturnCar(int carID)
        {
            ChangeCarStatus(carID);
            List<Rent> rents = Rents;
            foreach(var rent in rents)
            {
                if(rent.CarId == carID)
                {
                    rents.Remove(rent);
                    Rents = rents;
                    return;
                }
            }
        }

        public static void RentCar(int carId, int userId, DateTime expire)
        {
            ChangeCarStatus(carId);
            Rent rent = new Rent(DateTime.Now, expire, carId, userId);
            List<Rent> rents = Rents;
            rents.Add(rent);
            Rents = rents;
        }

        private static void ChangeCarStatus(int carID)
        {
            List<Car> cars = Cars;
            foreach(var car in cars)
            {
                if(car.Id == carID)
                {
                    car.IsRented = !car.IsRented;
                    Cars = cars;
                    return;
                }
            }
        }

        public static bool HaveRent(int userId)
        {
            foreach(var rent in Rents)
                if(rent.UserId == userId)
                    return true;
            return false;
        }
    }
}
