using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace SendPushoverNotification
{
    public class PushoverPoster
    {
        private string _title;
        private string _url;
        private string _message;

        public PushoverPoster(string title, string url, string message)
        {
            _message = message;
            _title = title;
            _url = url;
        }

        public bool Post()
        {
            var parameters = CreatePostParameters();

            using (var client = new WebClient())
            {
                if (Configuration.NetworkProxy.UseNetworkProxy)
                {
                    var credential = new NetworkCredential(Environment.UserName, GetPasswordFromConsoleInput(), Environment.UserDomainName);
                    var webProxyAddress = string.Concat(Configuration.NetworkProxy.Server, ":", Configuration.NetworkProxy.Port);
                    client.Proxy = new WebProxy(webProxyAddress, false, null, credential);
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

        public SecureString GetPasswordFromConsoleInput()
        {
            var pass = new SecureString();
            ConsoleKeyInfo key;

            Console.WriteLine("Enter password:");

            do
            {
                key = Console.ReadKey(true);

                if (Char.IsLetterOrDigit(key.KeyChar) || Char.IsPunctuation(key.KeyChar))
                {
                    pass.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                else if (key.Key != ConsoleKey.Enter)
                {
                    Console.Beep();
                    Console.Error.WriteLine("That character is not allowed.");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }
    }
}
