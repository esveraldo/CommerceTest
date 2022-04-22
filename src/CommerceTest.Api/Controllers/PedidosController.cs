using CommerceTest.Application.Dtos;
using CommerceTeste.Infra.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommerceTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly IPedidoService _pedidoService;

        public PedidosController(ILogger<ProdutosController> logger, IPedidoService pedidoService)
        {
            _logger = logger;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<PedidoDto>> ObterTodos()
        {
            try
            {
                var result = _pedidoService.ObterTodosOsPedidos();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDto>> ObterPorId(Guid id)
        {
            try
            {
                var result = _pedidoService.ObterPedidoPorId(id);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDto>> SalvarRegistro([FromBody] PedidoDto pedidoDto)
        {
            try
            {
                var result = _pedidoService.SalvarRegistroDoPedido(pedidoDto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<PedidoDto>> AlterarRegistro([FromBody] PedidoDto pedidoDto)
        {
            try
            {
                var result = _pedidoService.AlterarRegistroDoPedido(pedidoDto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<PedidoDto>> RemoverRegistro(Guid id)
        {
            try
            {
                var result = _pedidoService.DeletarRegistroDoPedido(id);
                if (result == null)
                    return Ok(new { Message = "Registro removido com sucesso." });

                return BadRequest(new { Message = "Houve um erro ao tentar remover o registro." });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
