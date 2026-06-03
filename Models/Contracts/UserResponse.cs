using Shared_Clipboard_Backend.Models.Contracts;

namespace Shared_Clipboard_Backend.Models.Contracts
{
    public record UserResponse(
        string Username,
        string Password,
        string Email
        );
}
