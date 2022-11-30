using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TeaAPI.MessageServices
{

    public class MessageService : IMessageService
    {
        public string Message { get; set; } = string.Empty;
        public MessageService()
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();
            channel.QueueDeclare(queue: "hello",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                Message = message;
                System.Console.WriteLine(" [x] Received from Rabbit: {0}", message);
            };
            channel.BasicConsume(queue: "hello",
                autoAck: true,
                consumer: consumer);
        }
        public string PullFromRabbit()
        {
            return Message;
        }
    }
}

