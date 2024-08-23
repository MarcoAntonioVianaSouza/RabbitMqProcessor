using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using RabbitMqProcessor.Models.Entities;

var factory = new ConnectionFactory { HostName = "localhost", UserName="admin", Password="admin" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "FilaMensagensSistema",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var json = Encoding.UTF8.GetString(body);

    RabbitMensagem mensagem = JsonSerializer.Deserialize<RabbitMensagem>(json);
    System.Threading.Thread.Sleep(1000);

    Console.WriteLine($" Nome {mensagem.Nome} - Texto {mensagem.Texto} - id {mensagem.Id}");
};

channel.BasicConsume(queue: "FilaMensagensSistema",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
