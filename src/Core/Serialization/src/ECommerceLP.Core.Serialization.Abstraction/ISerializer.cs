using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Serialization.Abstraction
{
    public interface ISerializer
    {
        string Serialize<T>(T value);

        T Deserialize<T>(string value);
    }
}
