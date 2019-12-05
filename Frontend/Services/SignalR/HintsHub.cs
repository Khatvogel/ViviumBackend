using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Frontend.Services.SignalR
{
    public class HintsHub : Hub<IHintClient>
    {
        public async Task Create() => await Clients.All.Create();
    }
}