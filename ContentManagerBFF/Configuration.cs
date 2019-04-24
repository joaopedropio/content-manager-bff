using Microsoft.Extensions.Configuration;
using System.IO;
using System.Runtime.InteropServices;

namespace ContentManagerBFF
{
    public class Configuration
    {
        public bool isWindowns { get { return RuntimeInformation.IsOSPlatform(OSPlatform.Windows); } }
        public string Port { get; }
        public string Domain { get; }
        public string URL { get; }
        public string FfmpegExecutablePath { get; }
        public string MP4BoxExecutablePath { get; }
        public string TempFolder { get; }
        public string ConvertedFolder { get; }
        public string CompresssedFolder { get; }
        public string SFTPHost { get; }
        public string SFTPUsername { get; }
        public string SFTPPassword { get; }

        public string ContentAPIURL { get; }

        public int SFTPPort { get; }

        public Configuration() : this(new ConfigurationBuilder().AddEnvironmentVariables().Build()) { }

        public Configuration(IConfigurationRoot configuration)
        {
            // Url
            this.Domain = configuration.GetValue<string>("API_DOMAIN") ?? "*";
            this.Port = configuration.GetValue<string>("API_PORT") ?? "80";
            this.URL = string.Format($"http://{this.Domain}:{this.Port}");

            // Content API
            this.ContentAPIURL = configuration.GetValue<string>("CONTENT_API_URL") ?? "http://localhost:8080";
        }
    }
}
