using ECommerceLP.Common.Serialization.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Serialization
{
    public class SerializerSettings:JsonSerializerSettings
    {
        public SerializerSettings()
        {
            this.ContractResolver = new CamelCasePropertyNamesContractResolver();
            this.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffffffzzz";
            this.Formatting = Formatting.Indented;
            this.Converters.Add(new PagedListConverter());
        }
    }
}
