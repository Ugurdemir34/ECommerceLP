using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Services
{
    public interface ICacheService
    {
        void SetValue(string key, string value);
        string GetValue(string key);
        void RemoveValue(string key);
        void SetList<T>(string key, IEnumerable<T> values);
        List<T> GetList<T>(string key);
        void RemoveList(string key);
    }
}
