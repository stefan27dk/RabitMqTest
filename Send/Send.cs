using System;
using RabbitMQ.Client;
using System.Text;

class Send
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

            
            // Message ................................................
            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);


            // Send Message ...........................................
            channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}