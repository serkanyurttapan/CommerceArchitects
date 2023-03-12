using BasketAPI.Dtos;
using BasketAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Shared.ControllerBases;

namespace BasketAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket(UserDto userDto)
        {
            return CreateActionResult(await _basketService.GetBasket(userDto.UserId));
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            return CreateActionResult(await _basketService.SaveOrUpdate(basketDto));
        }
    }
}
