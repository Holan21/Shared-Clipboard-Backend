using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Shared_Clipboard_Backend.Models.Entity;
using Shared_Clipboard_Backend.Services;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shared_Clipboard_Backend.Hubs
{
    [Authorize]
    public class ClipboardHub : Hub
    {
        private readonly ICLipboardRepositories _clipboardRepos;

        public ClipboardHub(ICLipboardRepositories clipboardRepos)
        {
            _clipboardRepos = clipboardRepos;
        }

        private static string GroupNameForUser(string userId) => $"user-{userId}";

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, GroupNameForUser(userId));
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupNameForUser(userId));
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendAdd(string text)
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return;

            var newItem = new ClipboardItem
            {
                Id = Guid.NewGuid(),
                Data = text,
                CreatedAt = DateTime.UtcNow
            };

            await _clipboardRepos.AddClipboardItemAsync(Guid.Parse(userId), newItem);
            await Clients.OthersInGroup(GroupNameForUser(userId)).SendAsync("ClipboardAdd", text);
        }

        public async Task SendDelete(string text)
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return;

            await _clipboardRepos.DeleteClipboardItemAsync(Guid.Parse(userId), text);
            await Clients.OthersInGroup(GroupNameForUser(userId)).SendAsync("ClipboardDelete", text);
        }
    }
}