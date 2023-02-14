
using System.Net; 
using Venus.Models; 
using System.Collections;

namespace Venus.Services
{
    public class PolarisConfig
    {
        public static string SelfUrl = "https://www.venus.lighting";
    }

    public class RedisConfigModel
    {
        public string Host = "";
        public string Password = "";
        public int Database = 0;

        public RedisConfigModel(string uri)
        {
            Uri myUri = new Uri(uri, UriKind.Absolute);
            this.Host = myUri.Host;
            var auth = myUri.AbsoluteUri.Split(":");
            if (auth.Length > 1)
            {
                this.Password = auth[1];
            }
            var queryDictionary = System.Web.HttpUtility.ParseQueryString(myUri.Query);
            var dbStr = queryDictionary["db"];
            if (!String.IsNullOrEmpty(dbStr))
            {
                var db = int.Parse(dbStr);
                this.Database = db;
            }
        }

    }

    public class ConfigModel
    {
        public string PgDsn { get; set; } = "";
        public RedisConfigModel? Redis { get; set; }
    }

    public class AwsConfig
    {  
        static AwsConfig()
        { 
        }

        static Dictionary<string, string> LoadConfigFromAws(string fileName, string envName)
        { 
            var dict = new Dictionary<string, string>();
            foreach (DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                if (item.Key == null || item.Value == null)
                    continue;
                var key = item.Key.ToString();
                var value = item.Value.ToString();
                if (key == null || value == null)
                    continue;
                dict[key] = value;
            }
            return dict;
        }

        public static ConfigModel GetConfig()
        {
            var configModel = new ConfigModel();
            var configContent = LoadConfigFromAws("main.config", "default");
            foreach (var e in configContent)
            {
                switch (e.Key)
                {
                    case "CSHARP_DSN":
                        configModel.PgDsn = e.Value;
                        break;
                }
            }
            return configModel;
        }
    }
}