namespace Shared.Settings
{
    public interface IDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string OrderCollectionName { get; set; }
        public string OrderItemCollectionName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
