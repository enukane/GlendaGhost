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

            Console.WriteLine("Post now!");

            tClient.PostMessage("こんにちは、アウタースペースから。こんどはsourceもセットしてみたその２");

            Console.WriteLine("Post done!");
            Console.ReadLine();

        }
    }
}
