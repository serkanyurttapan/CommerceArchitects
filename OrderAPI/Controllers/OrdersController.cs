using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderApplication.Commands;
using OrderApplication.Dtos;
using OrderApplication.Queries;
using Shared.ControllerBases;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders(UserDto userDto)
        {
            return CreateActionResult(await _mediator.Send(new GetOrdersByUserIdQuery()
            {
                UserId = userDto.UserId
            }));
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody]CreateOrderCommand createOrderCommand)
        {
            return CreateActionResult(await _mediator.Send(createOrderCommand));
        }
    }
}
