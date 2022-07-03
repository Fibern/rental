using System.Text.Json;
using System.IO;

namespace rental.Model
{
    public static class Serializer<T>
    {
        public static void Serialize(T t, string path)
        {
            var j = JsonSerializer.Serialize(t);
            File.WriteAllText(path, j);
        }

        public static T Deserialize(string path)
        {
            var txt = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(txt);
        }
    }
}
