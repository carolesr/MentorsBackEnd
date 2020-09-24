using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MentorsBackEnd.Hubs
{
    public class AppHub : Hub
    {
        public async Task SendNotificationLogin(string idCard)
        {
            await Clients.All.SendAsync("Login", idCard);
        }

        public async Task SendNotificationFinish(string message)
        {
            await Clients.All.SendAsync("Finish", message);
        }

        public async Task SendNotificationTeste(string message)
        {
            await Clients.All.SendAsync("Teste", message);
        }
    }
}
