1. In Docker Terminal "Client" to make RabitMq Image - new Image -            docker run -d --hostname my-rabit --name ecomm-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:management

2. Than I copied the IP which is "192.168.99.100:15672" with the port :15672 and used that in the RabitMq as hostname - "Copied from the docker kitematic app"

3. In RabitMQ Console App Send And Receive -      factory.HostName = "192.168.99.100";

4. In RabitMQ Console App Send And Receive -      factory.Port = AmqpTcpEndpoint.UseDefaultPort;   

5. Dont forget - Nuget- "RabbitMQ.Client" <PackageReference Include="RabbitMQ.Client" Version="6.2.1" />  for both SEND AND RECEIVE


6. In the Browser -  http://192.168.99.100:15672

7. Log IN - Username = guest     Password = guest   ----> "Need to be typed cant be pasted"


8. Go to ADMIN

9. ADD USER ----> at the bottom

10. Create new user

11. Click on the user

12. Go to Update this user

13. Enter the password for the user which was enterd on create

14. Click on  ADMIN

15. Click on Update user

16. ADD Username, password and Virtual path to the Send and Receive
Like so:

 ConnectionFactory factory = new ConnectionFactory();
        factory.UserName = "user123";
        factory.Password = "user123";
        factory.VirtualHost = "/";
        factory.HostName = "192.168.99.100";
        factory.Port = AmqpTcpEndpoint.UseDefaultPort;
        IConnection connection = factory.CreateConnection();



17. DONE ----> WORKS!!!