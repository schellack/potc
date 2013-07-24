using System;

namespace SendPushoverNotification
{
    class Program
    {
        static int Main()
        {
            var request = new ConsoleHelper().GetRequest();
            var pusher = new PushoverPoster(request.Title, request.Url, request.Message);
            var succeeded = pusher.Post();

            Console.WriteLine("Post sent.");
            System.Threading.Thread.Sleep(2000);
            
            return succeeded ? 1 : 0;
        }
    }
}
