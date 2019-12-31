using Microsoft.Extensions.Configuration;

namespace DockerSecretConfigurationProvider
{
    public class DockerSecretsConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ConfigDockerConfigurationProvider(SecretPath);
        }

        public string SecretPath { get; set; }
    }
}
