using System;
using System.Security;

namespace SendPushoverNotification
{
    public class ConsoleHelper
    {
        public SecureString GetPasswordFromConsoleInput()
        {
            ConsoleKeyInfo key;
            var pass = new SecureString();

            Console.WriteLine("Enter password:");

            do
            {
                key = Console.ReadKey(true);
                pass.AppendChar(GetKeyValue(key));
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }

        private static char GetKeyValue(ConsoleKeyInfo key)
        {
            var value = new char();
            if (Char.IsLetterOrDigit(key.KeyChar) || Char.IsPunctuation(key.KeyChar))
            {
                value = (key.KeyChar);
                Console.Write("*");
            }
            else if (key.Key != ConsoleKey.Enter)
            {
                Console.Beep();
                Console.Error.WriteLine("That character is not allowed.");
            }
            return value;
        }

        public PushRequest GetRequest()
        {
            // TODO: use a 3rd party library to more robustly handle parameters

            var args = Environment.GetCommandLineArgs();
            var request = new PushRequest();

            if (args.Length == 4 & args[0].Contains("SendPushoverNotification"))
            {
                args = new[] { args[1], args[2], args[3] };
            }

            if (args.Length == 3)
            {
                request.Message = args[0];
                request.Url = args[1];
                request.Title = args[2];
            }
            else
            {
                Console.WriteLine("Enter message:");
                request.Message = Console.ReadLine();
                Console.WriteLine(@"Enter url: (eg bufferapp:// or rivr://newpost or http://schellack.net)");
                request.Url = Console.ReadLine();
                Console.WriteLine("Enter title:");
                request.Title = Console.ReadLine();
            }

            return request;
        }
    }
}