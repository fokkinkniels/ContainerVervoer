using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServer_WebGLUnity
{
    class Program
    {

        static void Main(string[] args)
        {
            //Todo: 
            // -make ip/port configurable
            // -make it a package (or a gist?)
            // -make params container, stack etc.. configurable


            FleckWebSocketServer webSocketServer = new FleckWebSocketServer("127.0.0.1","8181");

            Console.WriteLine("\nUse <ENTER> to send a random ship layout to the ContainerVisualizer website.");
            Console.WriteLine("<ESCAPE> to quit");
            Console.WriteLine("\nNo socket client is connected yet...\n");

            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    string url;
                    url = ShipFactory.GenerateRandomShip();
                    Console.WriteLine(url);
                    foreach (var socket in webSocketServer.Sockets)
                    {
                        socket.Send(url);
                    }
                }
            }
        }

    }
}
