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
        private static string _usersPath = "../../../Resources/users.Json";
        public static List<User> Users { 
            get => Serializer<List<User>>.Deserialize(_usersPath);
            set => Serializer<List<User>>.Serialize(value, _usersPath);
        }
        
    }
}
