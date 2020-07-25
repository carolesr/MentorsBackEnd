using MentorsBackEnd.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorsBackEnd.Service
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _product;

        public ProductService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _product = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public List<Product> GetAll() =>
            _product.Find(product => true).ToList();

        public Product Get(string id) =>
            _product.Find<Product>(product => product.IdProduct == id).FirstOrDefault();
    }
}
