using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMqProcessor.Models.Entities;
using RabbitMqProcessor.Services.Interfaces;

namespace RabbitMqProcessor.Publisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMensagensController : ControllerBase
    {
        private readonly IRabbitMensagemService _service;

        public RabbitMensagensController(IRabbitMensagemService service)
        {
            _service = service;
        }
        [HttpPost]
        public void AddMensagem(RabbitMensagem mensagem) 
        {
            _service.SendMensagem(mensagem); 
        }
    }
}
