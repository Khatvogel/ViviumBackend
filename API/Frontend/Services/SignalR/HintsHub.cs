using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Frontend.Services.SignalR
{
    public class HintsHub : Hub
    {
        public async Task Create(int amount, List<Hint> hints) => await Clients.All.SendAsync("Create", amount, hints);
    }
}