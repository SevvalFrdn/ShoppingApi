namespace ShoppingApi.Entities
{
    public class ShoppingDatabaseSettings : IShoppingDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IShoppingDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string CategoryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
