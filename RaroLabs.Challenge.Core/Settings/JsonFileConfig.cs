using System;
using Microsoft.Extensions.Configuration;

namespace RaroLabs.Challenge.Core.Settings
{
	public static class JsonFileConfig
    {
        private static IConfigurationRoot config;

        public static IConfigurationRoot Get()
        {
            if (config != null)
                return config;

            var conf = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json");

            return config = conf.Build();
        }
    }
}