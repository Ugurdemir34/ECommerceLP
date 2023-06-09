using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Serialization.Abstraction
{
    public interface IJSONSerializer : ISerializer
    {
        string Serialize<T>(T value, JsonSerializerSettings settings);

        T Deserialize<T>(string value, JsonSerializerSettings settings);

        object? DeserializeObject(string value, Type type);

        bool ValidateJson(string json);
    }
}
