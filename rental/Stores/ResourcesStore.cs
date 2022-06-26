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

        public static BindableCollection<Car> Cars {
            get => Serializer<BindableCollection<Car>>.Deserialize(_path + "cars.Json");
            set => Serializer<BindableCollection<Car>>.Serialize(value, _path + "cars.Json");
        }

    }
}
