namespace Shared.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
        public string OrderCollectionName { get; set; }
        public string OrderItemCollectionName { get; set; }
    }
}
