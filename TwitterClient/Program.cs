using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace TwitterClient
{
    class Program
    {
        static void Main(string[] args)
        {
            String username;
            String password;
            
            Console.Write("Enter Username : ");
            username = Console.ReadLine().Trim();
            Console.WriteLine("Enter Password: ");
            password = Console.ReadLine().Trim();

            TwitterClient tClient = new TwitterClient(username, password);
            tClient.Start(30);

            while (true)
            {
                TweetMessage tMsg = tClient.GetMessage();

                if (tMsg == null)
                {
                    Thread.Sleep(1000);
                    continue;
                }
                
                String id = tMsg.Id;
                String user = tMsg.UserName;
                DateTime dt = tMsg.DateTime;
                String text = tMsg.Text;

                Console.WriteLine(@"{0} {1} {2} {3}", id, dt, user, text);

                Thread.Sleep(3000);
            }
        }
    }
}
