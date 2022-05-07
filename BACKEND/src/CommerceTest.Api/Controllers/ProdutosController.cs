using CommerceTest.Application.Dtos;
using CommerceTeste.Infra.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommerceTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly IProdutoService _produtoService;

        public ProdutosController(ILogger<ProdutosController> logger, IProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<ProdutoDto>> ObterTodos()
        {
            try
            {
                var result = await _produtoService.ObterTodosOsProdutos();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDto>> ObterPorId(Guid id)
        {
            try
            {
                var result = await _produtoService.ObterProdutoPorId(id); 
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> SalvarRegistro([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                var result = _produtoService.SalvarRegistroDoProduto(produtoDto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoDto>> AlterarRegistro([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                var result = _produtoService.AlterarRegistroDoProduto(produtoDto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ProdutoDto>> RemoverRegistro(Guid id)
        {
            try
            {
                var result = _produtoService.DeletarRegistroDoProduto(id);
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
