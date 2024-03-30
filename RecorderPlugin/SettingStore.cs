using Newtonsoft.Json;
using System;
using System.IO;
using HDT = Hearthstone_Deck_Tracker;

namespace RecorderPlugin
{
    internal class SettingStore
    {
        private string DataDir => Path.Combine(HDT.Config.Instance.DataDir, "OBSRecorder");

        private readonly string ConfigFile = "OBSRecorder.json";

        private string ConfigFilePath => Path.Combine(DataDir, ConfigFile);

        public void Save(string ip, string port, string password)
        {
            if (!Directory.Exists(DataDir))
            {
                Directory.CreateDirectory(DataDir);
            }

            Settings config = new Settings { IPAddress = ip, Port = port, Password = password };
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }

        public Settings? Load()
        {
            try
            {
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(ConfigFilePath));
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }

        public struct Settings
        {
            public string IPAddress;
            public string Port;
            public string Password;
        }
    }
}
