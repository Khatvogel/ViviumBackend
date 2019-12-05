using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Frontend.Services.SignalR
{
    public class HintsHub : Hub
    {
        public async Task Create(int amount) => await Clients.All.SendAsync("Create", amount);
    }
}