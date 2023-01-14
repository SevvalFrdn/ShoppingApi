using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingRedis.Configurations
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;

        public RedisConnectionFactory()
        {
            _connection = new Lazy<ConnectionMultiplexer>(valueFactory:()=> ConnectionMultiplexer.Connect(configuration:"localhost:"));
        }

        public ConnectionMultiplexer Connection()
        {
            return _connection.Value;
        }
    }
}
