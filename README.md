# MqttnetDemo
Small Demo to show how you can Host a Broker, Subscibe to topics and send messages

1. **Server** – MQTT broker that notifies when clients connect or disconnect.  
2. **Publisher** – Sends messages to a topic specified by the user.  
3. **Subscriber** – Subscribes to a topic and receives messages published to it.

   ## Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or higher
- [MQTTnet 5.x](https://github.com/chkr1011/MQTTnet)

The server is the MQTT broker. It listens on **port 1883** by default.
