using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;
using Newtonsoft.Json;
using WebSocketServer_WebGLUnity;

namespace ContainerSchipConsole
{
    class FleckWebSocketServer
    {
        public ReadOnlyCollection<IWebSocketConnection> Sockets => sockets.AsReadOnly();

        private List<IWebSocketConnection> sockets = new List<IWebSocketConnection>();

        public FleckWebSocketServer(string ip, string port)
        {

            var server = new WebSocketServer($"ws://{ip}:{port}");
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    sockets.Add(socket);
                    Console.WriteLine("Socket connection opened!");
                };

                socket.OnClose = () =>
                {
                    sockets.Remove(socket);
                    Console.WriteLine("Socket connection closed!");
                };

                socket.OnMessage = message =>
                {
                    if (message.ValidateJSON())
                    {
                        var obj = JsonConvert.DeserializeObject(message);
                        message = JsonConvert.SerializeObject(obj, Formatting.Indented);
                    }

                    Console.WriteLine("Message received: " + message);
                    //socket.Send("Response from server");
                };
            });
        }
    }
}
