using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Cache
{
    public interface IECommerceCache
    {
        Task SetValue<T>(string key, T value);
        Task<T> GetValue<T>(string key);
        void RemoveValue(string key);
        void SetList<T>(string key, IEnumerable<T> values);
        List<T> GetList<T>(string key);
        void RemoveList(string key);
    }
}
