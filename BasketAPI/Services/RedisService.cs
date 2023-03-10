

using StackExchange.Redis;

namespace BasketAPI.Services
{
    public class RedisService
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        private readonly string _host;
        private readonly int _port;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
            _connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379,abortConnect=false");
        }

        public IDatabase GetDB(int db = 0) => _connectionMultiplexer.GetDatabase(db);
    }
}