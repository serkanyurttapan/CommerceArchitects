using Amazon.Runtime.Internal;
using MediatR;
using OrderApplication.Dtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Commands
{
    public class CreateOrderCommand : IRequest<ResponseDto<CreatedOrderDto>>
    {
        public string BuyyerId { get; set; }
        public List<OrderItemDto> OrderItemsDto { get; set; }
        public AddressDto AddressDto { get; set; }
    }
}
