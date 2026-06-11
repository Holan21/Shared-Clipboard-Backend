using Microsoft.AspNetCore.SignalR;
using Shared_Clipboard_Backend.Hubs;
using System.Threading.Tasks;

namespace Shared_Clipboard_Backend.Services
{
    public class ClipboardNotifier
    {
        private readonly IHubContext<ClipboardHub> _hub;
        public ClipboardNotifier(IHubContext<ClipboardHub> hub) => _hub = hub;

        public Task NotifyAddForUser(string userId, string text) =>
                _hub.Clients.Group($"user-{userId}").SendAsync("ClipboardAdd", text);

        public Task NotifyDeleteForUser(string userId, string text) =>
            _hub.Clients.Group($"user-{userId}").SendAsync("ClipboardDelete", text);
    }
}