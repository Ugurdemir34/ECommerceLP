using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Library
{
    public class SingletonBase<T> where T : class
    {
        private static readonly Lazy<T> _instance = new(CreateInstanceOfT);

        protected SingletonBase()
        {
        }

        public static T GetInstance()
        {
            return _instance.Value;
        }

        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }
    }
}
