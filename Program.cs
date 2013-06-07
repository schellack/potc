using System;
using System.Collections.Specialized;
using System.Net;
using System.Security;

namespace SendPushoverNotification
{
    class Program
    {
        static int Main()
        {
            string message;
            string url;
            string title;
            var args = Environment.GetCommandLineArgs();
            if (args.Length == 4 & args[0].Contains("SendPushoverNotification"))
            {
                args = new[]{args[1], args[2], args[3]};
            }
            if (args.Length == 3)
            {
                message = args[0];
                url = args[1];
                title = args[2];
            }
            else //if (args.Length == 0)
            {
                Console.WriteLine("Enter message:");
                message = Console.ReadLine();
                Console.WriteLine(@"Enter url: (eg bufferapp:// or rivr://newpost or http://schellack.net)");
                url = Console.ReadLine();
                Console.WriteLine("Enter title:");
                title = Console.ReadLine();
            }
            //else
            //{
            //    Console.WriteLine("Please use parameters as follows:");
            //    Console.WriteLine("SendPushoverNotification.exe \"message\" url \"title\"");
            //    System.Threading.Thread.Sleep(2000);
            //    return;
            //}

            var pusher = new PushoverPoster(title, url, message);
            var succeeded = pusher.Post();

            Console.WriteLine("Post sent.");
            System.Threading.Thread.Sleep(2000);
            
            return succeeded ? 1 : 0;
        }


    }
}
