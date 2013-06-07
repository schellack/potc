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
                get 
                { 
                    var url = ConfigurationManager.AppSettings.Get ("PushoverUrl");
                    if(string.IsNullOrWhiteSpace(url))
                        throw new ConfigurationErrorsException("Pushover URL must be configured.");
                    Uri uri;
                    if (!Uri.TryCreate (url, UriKind.Absolute, out uri))
                    {
                        var badUrlMessage = string.Format ("Configured Pushover URL is not a valid URL: {0}", url);
                        throw new ConfigurationErrorsException (badUrlMessage);
                    }
                    return url;
                }
            }

            public static string Token
            {
                get 
                {
                    var token = ConfigurationManager.AppSettings.Get ("PushoverToken");
                    if(string.IsNullOrWhiteSpace(token))
                        throw new ConfigurationErrorsException("Pushover Token must be configured.");
                    return token;
                }
            }

            public static string User
            {
                get
                {
                    var user = ConfigurationManager.AppSettings.Get ("PushoverUser");
                    if(string.IsNullOrWhiteSpace(user))
                        throw new ConfigurationErrorsException("Pushover User must be configured.");
                    return user;
                }
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
