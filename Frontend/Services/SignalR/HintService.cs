using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Frontend.Services.SignalR
{
    public class HintService
    {
        private readonly IHubContext<HintsHub> _hubContext;

        public HintService(IHubContext<HintsHub> myHubContext)
        {
            _hubContext= myHubContext;
        }
        
        public async Task Create(int amount)
        {
            await _hubContext.Clients.All.SendAsync("CreateHint", amount);
        }      
    }
}