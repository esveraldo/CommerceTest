using CommerceTeste.Infra.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommerceTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PedidoProdutoController : ControllerBase
    {
        private readonly IPedidoProdutoService _pedidoProdutoService;
        private readonly ILogger<PedidoProdutoController> _logger;

        public PedidoProdutoController(IPedidoProdutoService pedidoProdutoService, ILogger<PedidoProdutoController> logger)
        {
            _pedidoProdutoService = pedidoProdutoService;
            _logger = logger;
        }

        [HttpGet("pedidos-com-produtos")]
        public async Task<ActionResult> PedidosComProdutos()
        {
            try
            {
                var result = await _pedidoProdutoService.ObterTodosOsPedidosComProdutos();
                if (result == null)
                    return NotFound(new { message = "Não foram encontrados registros." });
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("produtos-com-pedidos")]
        public async Task<ActionResult> ProdutosComPedidos()
        {
            try
            {
                var result = await _pedidoProdutoService.ObterTodosOsProdutosComPedidos();
                if (result == null)
                    return NotFound(new { message = "Não foram encontrados registros." });
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
