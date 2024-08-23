using RabbitMqProcessor.Models.Entities;

namespace RabbitMqProcessor.Services.Interfaces;
public interface IRabbitMensagemService
{
    void SendMensagem(RabbitMensagem mensagem);
   
}
