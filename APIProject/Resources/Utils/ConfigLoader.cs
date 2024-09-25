namespace APIProject.Resources.Utils

{
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class ConfigLoader
    {
        public static IConfiguration LoadConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return configurationBuilder.Build();
        }
    }

}

