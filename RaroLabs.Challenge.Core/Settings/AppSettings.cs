using Microsoft.Extensions.Configuration;
using RaroLabs.Challenge.Abstractions.Settings;

namespace RaroLabs.Challenge.Core.Settings
{
    public class AppSettings : IAppSettings
    {
        public ViaCepSettings GetViaCepSettings()
        {
            var config = JsonFileConfig.Get();
            var section = config?.GetSection($"ViaCep");
            return section?.Get<ViaCepSettings>();
        }
    }
}