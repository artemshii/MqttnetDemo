using System;
using MQTTnet;
using MQTTnet.Server;

namespace HelloWorld
{
    class Program
    {
        static async Task Main()
        {
            var mqttServer = await StartMqttServer();

            mqttServer.ClientConnectedAsync += (e =>
            {
                Console.WriteLine($"Client {e.ClientId} connected");
                return Task.CompletedTask;
            });

            mqttServer.ClientDisconnectedAsync += (e =>
            {
                Console.WriteLine($"Client {e.ClientId} disconnected");
                return Task.CompletedTask;
            });

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
            

            
            await mqttServer.StopAsync();
        }

        static async Task<MqttServer> StartMqttServer()
        {
            var mqttServerFactory = new MqttServerFactory();

            var mqttServerOptions = mqttServerFactory.CreateServerOptionsBuilder().WithDefaultEndpoint().Build();
            var server = mqttServerFactory.CreateMqttServer(mqttServerOptions);
            await server.StartAsync();
            return server;
        }
    }
}