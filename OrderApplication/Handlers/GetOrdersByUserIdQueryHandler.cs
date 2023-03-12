using AutoMapper.Internal.Mappers;
using Azure;
using MediatR;
using MongoDB.Driver;
using OrderApplication.Dtos;
using OrderApplication.Mapping;
using OrderApplication.OrderAggregate;
using OrderApplication.Queries;
using OrderInfrastructure;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, ResponseDto<OrderDto>>
    {
        private readonly IOrderDbContext _orderDbContext;
        public GetOrdersByUserIdQueryHandler(IOrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }
        public async Task<ResponseDto<OrderDto>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderDbContext.Orders.Find(x => x.BuyerId == request.UserId).FirstOrDefaultAsync();
            if (order is null)
                return ResponseDto<OrderDto>.Success((int)HttpStatusCode.OK);

            List<Order> orderModal = new();

            Order newOrder = new(order.BuyerId, order.Address);
            var orderItems = await _orderDbContext.OrderItems.Find(x => x.OrderId == order.Id).ToListAsync(cancellationToken);
            foreach (var orderItem in orderItems)
            {
                newOrder.AddOrderItem(orderItem.ProductId, orderItem.ProductName, orderItem.Price, orderItem.PictureUrl);
            }
            var orderDto = ObjectMapper.Mapper.Map<OrderDto>(newOrder);
            if (orderDto!=null)
            {
                orderDto.OrderItemDtos = ObjectMapper.Mapper.Map<List<OrderItemDto>>(newOrder.OrderItems);
            }
            return ResponseDto<OrderDto>.Success(orderDto, 200);
        }
    }
}
