using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Cache
{
    public class ECommerceCacheItem<T> : IEquatable<ECommerceCacheItem<T>>
    {
        public ECommerceCacheItem()
        {
            this.Key = nameof(T);
        }

        public ECommerceCacheItem(T item)
        {
            this.Key = typeof(T).Name;
            this.Value = item;
            this.Hash = this.Value?.GetHashCode() ?? 0;
        }

        public string Key { get; set; }

        public T Value { get; set; }

        public int Hash { get; set; }

        public bool Equals(ECommerceCacheItem<T> other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Key == other.Key && this.Hash == other.Hash;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((ECommerceCacheItem<T>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.Key != null ? this.Key.GetHashCode(StringComparison.CurrentCulture) : 0) * 397) ^ (this.Hash > 0 ? this.Hash.GetHashCode() : 0);
            }
        }
    }
}
