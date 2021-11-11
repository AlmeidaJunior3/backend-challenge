using Challenge.Domain.Commands;
using Challenge.Domain.Handler;
using Challenge.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly ChallengeHandler _handler;
        public ChallengeController(ChallengeHandler handler)
        {
            _handler = handler;                        
        }
         
        [HttpPost("pedido")]
        public IActionResult Post([FromBody] PedidoCommand command)
        {
            if (ModelState.IsValid)
                return Ok(_handler.GravarPedido(command));
            else
                return ModelStateHelper.RetornarMensagemValidacao(ModelState);
        }


        [HttpPost("status")]
        public IActionResult Post([FromBody] StatusCommand command)
        {
            if (ModelState.IsValid)
                return Ok(_handler.MudarStatus(command));
            else
                return ModelStateHelper.RetornarMensagemValidacao(ModelState);
        }
         
    }
}
