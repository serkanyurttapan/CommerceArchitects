using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using OrderApplication.OrderAggregate;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfrastructure
{
    public class OrderDbContext : IOrderDbContext
    {
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly IMongoCollection<OrderItem> _orderItemCollection;

        public OrderDbContext(IDatabaseSettings databaseSettings)
        {
            MongoClient client = new(databaseSettings.ConnectionStrings);
            IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
            _orderItemCollection = database.GetCollection<OrderItem>(databaseSettings.OrderItemCollectionName);
            _orderCollection = database.GetCollection<Order>(databaseSettings.OrderCollectionName);

        }

        public IMongoCollection<OrderItem> OrderItems => _orderItemCollection;
        public IMongoCollection<Order> Orders => _orderCollection;

    }
}
