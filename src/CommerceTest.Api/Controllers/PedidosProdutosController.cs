using CommerceTest.Application.Dtos;
using CommerceTeste.Infra.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommerceTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PedidosProdutosController : ControllerBase
    {
        private readonly ILogger<PedidosProdutosController> _logger;
        private readonly IPedidoProdutoService _pedidoProdutoService;

        public PedidosProdutosController(ILogger<PedidosProdutosController> logger, IPedidoProdutoService pedidoProdutoService)
        {
            _logger = logger;
            _pedidoProdutoService = pedidoProdutoService;
        }

        [HttpGet]
        public async Task<ActionResult<PedidoProdutoDto>> ObterTodos()
        {
            try
            {
                var result = _pedidoProdutoService.ObterTodosOsPedidoProdutos();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoProdutoDto>> ObterPorId(Guid id)
        {
            try
            {
                var result = _pedidoProdutoService.ObterPedidosProdutosPorId(id);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PedidoProdutoDto>> SalvarRegistro([FromBody] PedidoProdutoDto pedidoProdutoDto)
        {
            try
            {
                var result = _pedidoProdutoService.SalvarRegistroDoPedidoProduto(pedidoProdutoDto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<PedidoProdutoDto>> AlterarRegistro([FromBody] PedidoProdutoDto pedidoProdutoDto)
        {
            try
            {
                var result = _pedidoProdutoService.AlterarRegistroDoPedidoPedidosProduto(pedidoProdutoDto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<PedidoProdutoDto>> RemoverRegistro(Guid id)
        {
            try
            {
                var result = _pedidoProdutoService.DeletarRegistroDoPedidoPedidosProduto(id);
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
