using System;
using System.Collections.Specialized;
using System.Net;

namespace SendPushoverNotification
{
    public class PushoverPoster
    {
        private string _title;
        private string _url;
        private string _message;
        private readonly ConsoleHelper _consoleHelper;

        public PushoverPoster(string title, string url, string message)
        {
            _message = message;
            _title = title;
            _url = url;
            _consoleHelper = new ConsoleHelper();
        }

        public bool Post()
        {
            var parameters = CreatePostParameters();

            using (var client = new WebClient())
            {
                if (Configuration.NetworkProxy.UseNetworkProxy)
                {
                    client.Proxy = GetProxy();
                }
                client.UploadValues(Configuration.Pushover.Url, parameters);
            }

            return true;
        }

        private NameValueCollection CreatePostParameters()
        {
            var parameters = new NameValueCollection
                {
                    {"token", Configuration.Pushover.Token},
                    {"user", Configuration.Pushover.User},
                    {"message", _message},
                    {"url", _url},
                    {"title", _title}
                };
            return parameters;
        }

        private IWebProxy GetProxy()
        {
            var credential = new NetworkCredential(Environment.UserName,
                                                   _consoleHelper.GetPasswordFromConsoleInput().ToString(),
                                                   Environment.UserDomainName);
            var webProxyAddress = string.Concat(Configuration.NetworkProxy.Server, ":", Configuration.NetworkProxy.Port);
            return new WebProxy(webProxyAddress, false, null, credential);
        }
    }
}
