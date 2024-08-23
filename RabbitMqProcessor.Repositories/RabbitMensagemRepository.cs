using System.Text;
using RabbitMQ.Client;
using RabbitMqProcessor.Models.Entities;
using RabbitMqProcessor.Repositories.Interfaces;
using System.Text.Json;

namespace RabbitMqProcessor.Repositories;
public class RabbitMensagemRepository : IRabbitMensagemRepository
{
    public void SendMensagem(RabbitMensagem mensagem)
    {
        var factory = new ConnectionFactory { HostName = "localhost", UserName = "admin", Password = "admin" };
        
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "FilaMensagensSistema",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        string json = JsonSerializer.Serialize(mensagem);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: string.Empty,
                             routingKey: "FilaMensagensSistema",
                             basicProperties: null,
                             body: body);
      

    }
}
