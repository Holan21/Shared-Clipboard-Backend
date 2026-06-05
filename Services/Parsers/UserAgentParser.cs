using Shared_Clipboard_Backend.Models.Entity;
using Shared_Clipboard_Backend.Services.Parsers;
using System.Text.RegularExpressions;

namespace Shared_Clipboard_Backend.Services.UserAgen
{
    public class UserAgentParser : IUserAgentParser
    {
        private readonly Regex mainPattern = new (
            @"^(?<product>[^/]+)/(?<product_version>[^ ]+)\s*\((?<platform>[^)]+)\)\s*(?<engine>[^/]+)/(?<engine_date>[^ ]+)\s*(?<browser>[^/]+)/(?<browser_version>.+)$",
            RegexOptions.Compiled);
        public async Task<Device> ParseAsync(string parse)
        {
            var result = new Device();
            var match = mainPattern.Match(parse);

            if (!match.Success) throw new Exception();

            var platform = match.Groups["platform"].Value.Trim();
            var parts = platform.Split(';');
            if (parts.Length > 0) result.OS = parts[0].Trim();

            for (int i = 0; i < parts.Length; i++) parts[i] = parts[i].Trim();
            result.AcsebilityToken = string.Join("; ", parts);

            var engine = match.Groups["engine"].Value.Trim();
            var engineDate = match.Groups["engine_date"].Value.Trim();
            if (!string.IsNullOrEmpty(engine))
                result.Engine = !string.IsNullOrEmpty(engineDate) ? $"{engine}/{engineDate}" : engine;

            var browser = match.Groups["browser"].Value.Trim();
            var browserVersion = match.Groups["browser_version"].Value.Trim();
            if (!string.IsNullOrEmpty(browser))
                result.Browser = !string.IsNullOrEmpty(browserVersion) ? $"{browser}/{browserVersion}" : browser;

            return result;
        }
    }
}

