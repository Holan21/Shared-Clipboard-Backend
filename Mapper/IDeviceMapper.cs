using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Models.Entity;

namespace Shared_Clipboard_Backend.Mapper
{
    public interface IDeviceMapper
    {
        public Task<Device> ToEntityAsync(DeviceResponse response);
    }
}
