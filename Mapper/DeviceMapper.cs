using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Models.Entity;

namespace Shared_Clipboard_Backend.Mapper
{
    public class DeviceMapper : IDeviceMapper
    {
        public async Task<Device> ToEntityAsync(DeviceResponse response)
        {
            return new Device
            {
                 Id = Guid.NewGuid(),
                 Name = response.Name,
                 OSName = response.OSName,
            };
        }
    }
}
