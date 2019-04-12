using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentManagerBFFTests
{
    public class Configurations
    {
        private static IConfiguration Configuration => new ConfigurationBuilder().AddEnvironmentVariables().Build();
        public static string GetContentApiUrl()
        {
            var contentApiUrl = Configuration.GetValue<string>("CONTENT_API_URL");
            if (string.IsNullOrEmpty(contentApiUrl))
                return "http://localhost:8080";

            return contentApiUrl;
        }
    }
}
