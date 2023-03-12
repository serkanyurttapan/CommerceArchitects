using MediatR;
using OrderApplication.Dtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<ResponseDto<OrderDto>>
    {
        public string UserId { get; set; }
    }
}
