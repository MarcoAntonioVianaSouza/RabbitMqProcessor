using RabbitMqProcessor.Models.Entities;
using RabbitMqProcessor.Repositories.Interfaces;
using RabbitMqProcessor.Services.Interfaces;

namespace RabbitMqProcessor.Services;

public class RabbitMensagemService : IRabbitMensagemService
{
    readonly IRabbitMensagemRepository _repository;

    public RabbitMensagemService(IRabbitMensagemRepository repository)
    {
        _repository = repository;
    }

    public void SendMensagem(RabbitMensagem mensagem)
    {
        _repository.SendMensagem(mensagem);
    }
}
