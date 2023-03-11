using StackExchange.Redis;
namespace BasketAPI.Services
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        ConnectionMultiplexer? _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDB(int db = 0) => _connectionMultiplexer.GetDatabase(db);
    }
}