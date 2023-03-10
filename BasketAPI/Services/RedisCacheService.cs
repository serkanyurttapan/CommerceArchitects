using Newtonsoft.Json;

namespace BasketAPI.Services
{
    public class RedisCacheService : IRedisCacheService
    {

        private RedisService _redisService;
        public RedisCacheService(RedisService redisService)
        {
            _redisService = redisService;
        }
        public void Add(string key, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            _redisService.GetDB().StringSet(key, jsonData);
        }

        public bool Any(string key)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
