﻿using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {

        ConnectionFactory factory = new ConnectionFactory();
        factory.UserName = "user123";
        factory.Password = "user123";
        factory.VirtualHost = "/";
        factory.HostName = "192.168.99.100";
        factory.Port = AmqpTcpEndpoint.UseDefaultPort;
        IConnection connection = factory.CreateConnection();

        while(true)
        {

        //using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            string message = Console.ReadLine();
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        //Console.WriteLine(" Press [enter] to exit.");
        //Console.ReadLine();
        }
    }
}