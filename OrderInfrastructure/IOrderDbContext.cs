using MongoDB.Driver;
using OrderApplication.OrderAggregate;

namespace OrderInfrastructure
{
    public interface IOrderDbContext
    {
        IMongoCollection<Order> Orders { get; }
        IMongoCollection<OrderItem> OrderItems { get; }
    }
}
