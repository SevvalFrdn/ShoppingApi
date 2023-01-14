using Newtonsoft.Json;
using ShoppingRedis.Configurations;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ShoppingRedis.Redis
{
    public class RedisCacheManager : ICacheServices
    {

        private readonly IRedisConnectionFactory _connection;
        private readonly IDatabase _database;
        public RedisCacheManager(IRedisConnectionFactory connection)
        {
            _connection = connection;
            _database = _connection.Connection().GetDatabase(0);
        }

        public T Get<T>(string key)
        {
            if (!Any(key)) return default;
            string stringData = _database.StringGet(key);
            var jsonData = JsonConvert.DeserializeObject<T>(stringData);
            return jsonData;
        }
        public void Add(string key, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            _database.StringSet(key, jsonData);

        }


        public void Clear()
        {
            _database.Multiplexer.GetServer("http:localhost:").FlushDatabase();
        }
        public bool Any(string key)
        {
            return _database.KeyExists(key);
        }

        public void Remove(string key)
        {
           _database.KeyDelete(key);
        }
    }
}
