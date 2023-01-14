using MongoDB.Driver;
using ShoppingApi.Entities;
using System.Collections.Generic;

namespace ShoppingApi.Services
{
    public class ProductServices
    {
        private readonly IMongoCollection<Product> _product;

        public ProductServices(IShoppingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _product = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public List<Product> Get() => _product.Find(product => true).ToList();

        public Product Get(string id) => _product.Find<Product>(product =>  product.Id == id).FirstOrDefault();

        public Product Create(Product product)
        {
            _product.InsertOne(product);
            return product;
        }

        public void Update(string id, Product product) =>
            _product.ReplaceOne(product => product.Id == id, product);

        public void Remove(Product product) =>
            _product.DeleteOne(product => product.Id == product.Id);

        public void Remove(string id) =>
            _product.DeleteOne(product => product.Id == id);
    }
}
