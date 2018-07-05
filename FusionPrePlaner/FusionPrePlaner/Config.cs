using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Linq.Expressions;
namespace FusionPrePlaner
{
    [Serializable]
    class Config 
    {
        private static Config _config_instance;
        const int DEFAULT_INTERVAL = 10; //minutes
        const bool DEFAULT_AUTORUN = true;
        const bool DEFAULT_RUN_ON_START = false;

        const string DEFAULT_RESTAPI_PATH = "https://jiradc.int.net.nokia.com/rest/api/latest/";
        const string DEFAULT_USERNAME = "";
        const string DEFAULT_PASSWORD = "";

        private Config()
        {
            PrePlanInterval = DEFAULT_INTERVAL;
            AutoRun = DEFAULT_AUTORUN;
            RunOnStart = DEFAULT_RUN_ON_START;
            RestApi_Path = DEFAULT_RESTAPI_PATH;
            UserName = DEFAULT_USERNAME;
            Password = DEFAULT_PASSWORD;
        }
        public static Config Instance
        {
            get
            {
                if (_config_instance == null)
                {
                    _config_instance = Deserialize();

                }
                return _config_instance;
            }
            
        }
        public int PrePlanInterval { get; set; }
        
      
        public bool AutoRun { get; set; }
        public bool RunOnStart { get; set; }
        public string RestApi_Path { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static void Serialize(Config config)
        {
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("config.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, config);
            stream.Close();
        }

        public static Config Deserialize()
        {

            IFormatter formatter = new BinaryFormatter();
            try
            {
                Stream stream = new FileStream("config.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Config config = formatter.Deserialize(stream) as Config;
                stream.Close();
                return config;
            }
            catch
            {
                return new Config();
            }
           
        }
    }
}
