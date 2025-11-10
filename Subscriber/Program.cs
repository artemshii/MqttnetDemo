using System;
using System.Text;
using MQTTnet;


namespace Subscriber
{
    public class Program
    {
        static async Task Main()
        {
            var factory = new MqttClientFactory();
            var mqttClient = factory.CreateMqttClient();

            
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883) 
                .Build();
            var connectedResult = await mqttClient.ConnectAsync(options);

            if(connectedResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                while (true)
                {
                    Console.WriteLine("1 - Connect To Topic");
                    Console.WriteLine("2 - Disonnect From Topic");
                    Console.WriteLine("3 - Disconnect from Server");
                    string result = Console.ReadLine();

                    if (result == "1")
                    {
                        Console.WriteLine("Enter Topic Name");
                        string topicName = Console.ReadLine();
                        if(topicName != null)
                        {
                            await mqttClient.SubscribeAsync(topicName);
                            mqttClient.ApplicationMessageReceivedAsync += e =>
                            {
                                Console.WriteLine($"Received message {System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                                
                                return Task.CompletedTask;
                            };
                        }
                    }
                    else if (result == "2")
                    {
                        Console.WriteLine("Enter Topic Name");
                        string topicName = Console.ReadLine();
                        if (topicName != null)
                        {
                            await mqttClient.UnsubscribeAsync(topicName);
                        }
                        
                    }
                    else if (result == "3")
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
}