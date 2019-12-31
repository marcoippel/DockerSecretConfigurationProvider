using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DockerSecretConfigurationProvider
{
    public class ConfigDockerConfigurationProvider : ConfigurationProvider
    {
        private readonly string _secretPath;

        public ConfigDockerConfigurationProvider(string secretPath)
        {
            _secretPath = secretPath;
        }

        public override void Load()
        {
            if (!Directory.Exists(_secretPath))
            {
                return;
            }

            var files = Directory.GetFiles(_secretPath);
                
            Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var filePath in files)
            {
                var fileName = Path.GetFileName(filePath);
                var content = File.ReadAllText(filePath);
                Data[fileName] = content;
            }
        }
    }
}