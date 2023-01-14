using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingRedis.Redis
{
    public interface ICacheServices
    {
        T Get<T>(string key) ;
        void Add(string key, object data);
        void Remove(string key);
        void Clear();
        bool Any(string key);
    }
}
