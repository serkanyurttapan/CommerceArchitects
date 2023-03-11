using OrderDomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public Address Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BuyerId { get; set; }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {
        }
        public Order(string buyerId, Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }
        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
        {
            bool existProduct = _orderItems.Any(x => x.ProductId == productId);
            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, price);
                _orderItems.Add(newOrderItem);
            }
        }
        public decimal GetOrderTatolPrice()
        {
            return _orderItems.Sum(x => x.Price);
        }
    }
}
