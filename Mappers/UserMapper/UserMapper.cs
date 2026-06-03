
using Shared_Clipboard_Backend.Mappers.ClipboardMapper;
using Shared_Clipboard_Backend.Mappers.DeviceMapper;
using Shared_Clipboard_Backend.Models;
using Shared_Clipboard_Backend.Models.Dto;

/*namespace Shared_Clipboard_Backend.Mappers.UserMapper
{
    public class UserMapper
        (IDeviceMapper deviceMapper,
        IClipboardItemMapper clipboardMapper) : IUserMapper
    {
        private readonly IDeviceMapper _deviceMapper = deviceMapper;
        private readonly IClipboardItemMapper _clipboardMapper = clipboardMapper;
        public async Task<User> ToDtoAsync(UserDto user)
        {
            var deviceList = (List<Device>)
                user.Devices.Select(async device => (await Task.WhenAll(_deviceMapper.ToDtoAsync(device)))
                .ToList());

            var clipboard = (List<ClipboardItem>)
                user.Clipboard.Select(async item => (await Task.WhenAll(_clipboardMapper.ToDtoAsync(item)))
                .ToList());


            return new User
            {
                Email = user.Email,
                Devices = deviceList,
                CreatedAt = user.CreatedAt,
                Password = user.Password,
                SharedClipboard = clipboard,
                Username = user.Username,
            };
        }
    }
}*/
