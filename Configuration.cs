using System;
using System.Configuration;

namespace SendPushoverNotification
{
    public static class Configuration
    {
        public static class Pushover
        {
            public static string Url
            {
                get { return ConfigurationManager.AppSettings.Get("PushoverUrl"); }
            }

            public static string Token
            {
                get { return ConfigurationManager.AppSettings.Get("PushoverToken"); }
            }

            public static string User
            {
                get { return ConfigurationManager.AppSettings.Get("PushoverUser"); }
            }
        }

        public static class NetworkProxy
        {
            public static bool UseNetworkProxy
            {
                get { return bool.Parse(ConfigurationManager.AppSettings.Get("UseNetworkProxy")); }
            }

            public static string Server
            {
                get { return ConfigurationManager.AppSettings.Get("NetworkProxyServer"); }
            }

            public static int Port
            {
                get { return int.Parse(ConfigurationManager.AppSettings.Get("NetworkProxyPort")); }
            }
        }
    }
}
