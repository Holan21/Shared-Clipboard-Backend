namespace Shared_Clipboard_Backend.Models.Contracts
{
    public record DeviceResponse(
        string OS,
        string AcsebilityToken,
        string Engine,
        string Browser
        );
}
