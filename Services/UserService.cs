using MentorsBackEnd.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MentorsBackEnd.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MentorsBackEnd.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;
        private readonly IHubContext<AppHub> _hub;

        public UserService(IDatabaseSettings settings, IHubContext<AppHub> hub)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.UserCollectionName);
            _hub = hub;
        }

        public List<User> GetAll() =>
            _user.Find(user => true).ToList();

        public User Get(int id)
        {
            return  _user.Find(user => user.IdCard == id).FirstOrDefault();
        }

        public User Create(User u)
        {
            if (u != null)
                _user.InsertOne(u);
            return u;
        }

        public void Update(User u)
        {
            if (u != null)
                _user.ReplaceOne(user => user.IdUser == u.IdUser, u);
        }

        public Task SendNotificationAsync(string message)
        {
            return _hub.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
