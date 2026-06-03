using Shared_Clipboard_Backend.Models.Entity;

namespace Shared_Clipboard_Backend.Services.Parsers
{
    public interface IUserAgentParser
    {
        public Task<Device> ParseAsync(string parse);
    }
}
