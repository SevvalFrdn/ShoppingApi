using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace ShoppingRedis.Configurations
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
    }
}
