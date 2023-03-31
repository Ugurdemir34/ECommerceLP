using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceLP.Common.Serialization;
using ECommerceLP.Common.Serialization.Abstract;

namespace ECommerceLP.Common.Json
{
    public class JSONSerializer : IJSONSerializer
    {
        private readonly SerializerSettings _serializerSettings;

        public JSONSerializer()
        {
            this._serializerSettings = new SerializerSettings();
        }

        public string Serialize<T>(T value, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(value, settings);
        }

        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, this._serializerSettings);
        }

        public T Deserialize<T>(string value, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(value, settings);
        }

        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, this._serializerSettings);
        }

        public object DeserializeObject(string value, System.Type type)
        {
            return JsonConvert.DeserializeObject(value, type, this._serializerSettings);
        }

        public bool ValidateJson(string json)
        {
            json = json.Trim();
            try
            {
                if (json.StartsWith("{") && json.EndsWith("}"))
                {
                    JToken.Parse(json);
                }
                else if (json.StartsWith("[") && json.EndsWith("]"))
                {
                    JArray.Parse(json);
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
