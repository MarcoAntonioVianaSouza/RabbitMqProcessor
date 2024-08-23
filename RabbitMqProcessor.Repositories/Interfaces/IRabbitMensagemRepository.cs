using RabbitMqProcessor.Models.Entities;
using System;

namespace RabbitMqProcessor.Repositories.Interfaces;

public interface IRabbitMensagemRepository
{
    void SendMensagem(RabbitMensagem mensagem);
}
