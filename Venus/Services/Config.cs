
using System.Net;
using Amazon.AppConfig;
using Amazon.AppConfig.Model;
using Amazon.AppConfigData;
using Amazon.AppConfigData.Model;
using Venus.Models;
using Microsoft.EntityFrameworkCore;
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
        static private ConfigModel? currentConfig;
        //static Dictionary<string, string> DefaultMap = new Dictionary<string, string>();

        static AwsConfig()
        {
            //ParseAppConfig();
        }

        static Dictionary<string, string> LoadConfigFromAws(string fileName, string envName)
        {
            // const string configUrl = "http://127.0.0.1:8001/config/select?project=polaris"; 
            // using var client = new HttpClient();

            // var response = await client.GetAsync(configUrl); 
            // var result = await response.Content.ReadAsStringAsync();

            // return result;
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

        public static async Task<ConfigModel> GetConfig()
        {
            if (currentConfig != null)
            {
                return currentConfig;
            }
            var configModel = new ConfigModel();
            var configContent = await LoadConfigFromAws("main.config", "default");
            if (String.IsNullOrEmpty(configContent))
                throw new Exception("aws 配置为空");
            var configArray = configContent.Split("\n");
            foreach (var e in configArray)
            {
                var index = e.IndexOf("=");
                if (index < 0) continue;
                var key = e.Substring(0, index);
                var value = e.Substring(index + 1);
                switch (key)
                {
                    case "CSHARP_DSN":
                        configModel.PgDsn = value;
                        break;
                    case "REDIS":
                        configModel.Redis = new RedisConfigModel(value);
                        break;
                }
            }
            currentConfig = configModel;
            return configModel;
        }
    }
}