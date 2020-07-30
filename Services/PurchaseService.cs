using MentorsBackEnd.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MentorsBackEnd.Services
{
    public class PurchaseService
    {
        private readonly IMongoCollection<Purchase> _purchase;

        public PurchaseService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _purchase = database.GetCollection<Purchase>(settings.PurchaseCollectionName);
        }

        public List<Purchase> GetAll() =>
            _purchase.Find(purchase => true).ToList();

        public Purchase Create(Purchase p)
        {
            if (p != null)
                _purchase.InsertOne(p);
            return p;
        }
            
    }
}
