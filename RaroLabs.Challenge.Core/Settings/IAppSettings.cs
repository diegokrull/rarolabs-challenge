using RaroLabs.Challenge.Abstractions.Settings;

namespace RaroLabs.Challenge.Core.Settings
{
    public interface IAppSettings
    {
        ViaCepSettings GetViaCepSettings();
    }
}