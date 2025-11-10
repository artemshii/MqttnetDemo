using MQTTnet;

using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var factory = new MqttClientFactory();
        var mqttClient = factory.CreateMqttClient();

        
        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("localhost", 1883) 
            .Build();
        var connectedResult = await mqttClient.ConnectAsync(options);

        if (connectedResult.ResultCode == MqttClientConnectResultCode.Success)
        {
            while (true)
            {
                Console.WriteLine("1 - Send Messages");
                Console.WriteLine("2 - Disconnect from Server");
                string result = Console.ReadLine();

                if (result == "1")
                {
                    Console.WriteLine("Enter Topic Name");
                    string topicName = Console.ReadLine();
                    if(topicName != null)
                    {
                        Console.WriteLine("Enter message");
                        string msg = Console.ReadLine();
                            var message = new MqttApplicationMessageBuilder()
                        .WithTopic(topicName)
                        .WithPayload(msg)
                        .WithRetainFlag()
                        .Build();

                        await mqttClient.PublishAsync(message);
                    }    
                    
                }
                else if (result == "2")
                {
                    await mqttClient.DisconnectAsync();
                }
                else
                {
                    continue;
                }

            }
        }

            
        
    }
}
