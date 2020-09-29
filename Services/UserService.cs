using MentorsBackEnd.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MentorsBackEnd.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MentorsBackEnd.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;
        private readonly IHubContext<AppHub> _hub;
        private readonly PurchaseService _purchaseService;

        public UserService(IDatabaseSettings settings, IHubContext<AppHub> hub)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.UserCollectionName);
            _hub = hub;
            _purchaseService = new PurchaseService(settings);
        }

        public List<User> GetAll() =>
            _user.Find(user => true).ToList();

        public User Get(int id)
        {
            return  _user.Find(user => user.IdCard == id).FirstOrDefault();
        }

        public User CreateUser(User u)
        {
            _user.InsertOne(u);
            UpdatePurchase(u.IdUser);
            return u;
        }
        public void DeleteUser(int idCard)
        {
            _user.DeleteOne(user => user.IdCard == idCard);
        }

        public void VerifyUser(int idCard)
        {
            var user = _user.Find(user => user.IdCard == idCard).FirstOrDefault();
            if (user != null)
                UpdatePurchase(user.IdUser);
            else
                SendNotificationLogin(idCard.ToString());
        }

        public void UpdatePurchase(string idUser)
        {
            _purchaseService.UpdatePurchase(idUser);
            SendNotificationFinish("Success");
        }

        public void SendNotificationLogin(string idCard)
        {
            _hub.Clients.All.SendAsync("Login", idCard);
        }

        public void SendNotificationFinish(string idCard)
        {
            _hub.Clients.All.SendAsync("Finish", idCard);
        }

        public void TesteSignalR(string idCard)
        {
            _hub.Clients.All.SendAsync("Teste", idCard);
        }
    }
}
