using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterMoon.Core.Caching
{
    public partial class NopNullCache : ICacheManager
    {
        public virtual T Get<T>(string key)
        {
            return default(T);
        }

        public virtual void Set(string key, object data, int cacheTime)
        {
        }

        public bool IsSet(string key)
        {
            return false;
        }

        public virtual void Remove(string key)
        {
        }

        public virtual void RemoveByPattern(string pattern)
        {
        }

        public virtual void Clear()
        {
        }
    }
}
