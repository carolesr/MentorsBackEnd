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

        public Purchase CreatePurchase(Purchase p)
        {
            if (p != null)
                _purchase.InsertOne(p);
            return p;
        }

        public void UpdatePurchase(string idUser)
        {
            var purchase = _purchase.Find(p => p.Pending == "true").SortByDescending(x => x.IdPurchase).FirstOrDefault();
            if (purchase != null)
            {
                purchase.IdUser = idUser;
                purchase.Pending = "false";
                _purchase.ReplaceOne(pur => pur.IdPurchase == purchase.IdPurchase, purchase);
            }            
        }
            
    }
}
