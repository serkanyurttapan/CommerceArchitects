using BasketAPI.Dtos;
using Newtonsoft.Json;
using Shared.Dtos;
using StackExchange.Redis;
using System.Net;

namespace BasketAPI.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<ResponseDto<bool>> Delete(string userId)
        {
            bool status = await _redisService.GetDB().KeyDeleteAsync(userId);

            if (status)
                return ResponseDto<bool>.Success((int)HttpStatusCode.NoContent);

            return ResponseDto<bool>.Fail("basket not found", (int)HttpStatusCode.NotFound);
        }

        public async Task<ResponseDto<BasketDto>> GetBasket(string userId)
        {
            RedisValue existBasket = await _redisService.GetDB().StringGetAsync(userId);

            if (string.IsNullOrEmpty(existBasket))
            {
                return ResponseDto<BasketDto>.Fail("basket not found", (int)HttpStatusCode.NotFound);
            }
            return ResponseDto<BasketDto>.Success(JsonConvert.DeserializeObject<BasketDto>(existBasket),
                                                  (int)HttpStatusCode.OK);
        }

        public async Task<ResponseDto<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            bool status = await _redisService.GetDB().StringSetAsync(basketDto.UserDto.UserId,JsonConvert.SerializeObject(basketDto));
            if (status)

            {
                return ResponseDto<bool>.Success((int)HttpStatusCode.NoContent);
            }
            return ResponseDto<bool>.Fail("basket could not updated", (int)HttpStatusCode.BadRequest);
        }
    }
}
