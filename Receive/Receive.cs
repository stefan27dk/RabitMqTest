using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

class Receive
{
    public static void Main()
    {


        // Connection Factory---------------------------------------------------------------------------
        ConnectionFactory factory = new ConnectionFactory() 
        {
            UserName = "user123",
            Password = "user123",
            VirtualHost = "/",
            HostName = "192.168.99.100",
            Port = AmqpTcpEndpoint.UseDefaultPort
        };



        // Connection / Chanel ---------------------------------------------------------------------------
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
            {
          
            // QUEUE................................................
             channel.QueueDeclare(
                    queue: "hello", 
                    durable: false, 
                    exclusive: false, 
                    autoDelete: false, 
                    arguments: null);   

                Console.WriteLine(" [*] Waiting for messages.");


            // Listen for messages.....................................
            var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };

                channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);
            
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
         




    }
}