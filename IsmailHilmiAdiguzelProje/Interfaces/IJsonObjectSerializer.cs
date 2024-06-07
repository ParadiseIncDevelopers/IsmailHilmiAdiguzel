using IsmailHilmiAdiguzelProje.Models;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace IsmailHilmiAdiguzelProje.Interfaces
{
    public class JsonObjectSerializer<T>
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

        public static T? DeserializeObject(object value) 
        {
            
            string serializedString = JsonSerializer.Serialize((T)value, options);
            T? user = JsonSerializer.Deserialize<T>(serializedString);
            return user;
        }
    }
}
