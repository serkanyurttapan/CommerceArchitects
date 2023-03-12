using MediatR;
using OrderApplication.Commands;
using OrderApplication.Dtos;
using OrderApplication.OrderAggregate;
using OrderInfrastructure;
using Shared.Dtos;
using System.Net;

namespace OrderApplication.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseDto<CreatedOrderDto>>
    {
        private readonly IOrderDbContext _orderDbContext;

        public CreateOrderCommandHandler(IOrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<ResponseDto<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.AddressDto.Province, request.AddressDto.District, request.AddressDto.Street, request.AddressDto.ZipCode, request.AddressDto.Line);

            Order newOrder = new(request.BuyyerId, newAddress);

            await _orderDbContext.Orders.InsertOneAsync(newOrder);

            request.OrderItemsDto.ForEach(async x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
                var newOrderItem = new OrderItem(x.ProductId, x.ProductName, x.PictureUrl, x.Price, newOrder.Id);
                await _orderDbContext.OrderItems.InsertOneAsync(newOrderItem);
            });

            return ResponseDto<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, (int)HttpStatusCode.OK);
        }
    }
}
