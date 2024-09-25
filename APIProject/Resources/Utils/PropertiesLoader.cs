namespace APIProject.Resources.Utils
{
    using System.Collections.Generic;
    using System.IO;

    public static class PropertiesLoader
    {
        private static readonly string propertiesFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/data.properties");

        public static Dictionary<string, string> LoadProperties()
        {
            var properties = new Dictionary<string, string>();

            foreach (var line in File.ReadAllLines(propertiesFilePath))
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    var keyValue = line.Split('=');
                    properties.Add(keyValue[0].Trim(), keyValue[1].Trim());
                }
            }

            return properties;
        }
    }

}

