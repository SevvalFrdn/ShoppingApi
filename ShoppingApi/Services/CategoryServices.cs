using MongoDB.Driver;
using ShoppingApi.Entities;
using System.Collections.Generic;

namespace ShoppingApi.Services
{
    public class CategoryServices
    {
        private readonly IMongoCollection<Category> _category;

        public CategoryServices(IShoppingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _category = database.GetCollection<Category>(settings.CategoryCollectionName);
        }

        public List<Category> Get() => _category.Find(category => true).ToList();

        public Category Get(string id) => _category.Find<Category>(category => category.Id == id).FirstOrDefault();

        public Category Create(Category category)
        {
            _category.InsertOne(category);
            return category;
        }

        public void Update(string id, Category category) =>
            _category.ReplaceOne(category => category.Id == id, category);

        public void Remove(Category category) =>
            _category.DeleteOne(category => category.Id == category.Id);

        public void Remove(string id) =>
            _category.DeleteOne(category => category.Id == id);
    }
}
