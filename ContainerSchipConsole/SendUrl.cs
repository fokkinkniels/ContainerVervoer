using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchipConsole
{
    public static class SendUrl
    {

        public static void SendCustomUrl(string url)
        {
            FleckWebSocketServer webSocketServer = new FleckWebSocketServer("127.0.0.1", "8181");

            Console.WriteLine();
            Console.WriteLine(url);
            Console.WriteLine();


            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    foreach (var socket in webSocketServer.Sockets)
                    {
                        socket.Send(url);
                    }
                }
            }
        }

    }
}
