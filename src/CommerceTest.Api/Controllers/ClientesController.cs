using CommerceTest.Application.Dtos;
using CommerceTeste.Infra.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommerceTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ObterTodos()
        {
            try
            {
                var result = await _clienteService.ObterTodosOsClientes();

                if (result == null)
                    return NotFound(new { message = "Não foram encontrados registros." });

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("clientes-com-pedidos")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ObterTodosComPedido()
        {
            try
            {
                var result = await _clienteService.ObterTodosOsClientesComPedidos();

                if (result == null)
                    return NotFound(new { message = "Não foram encontrados registros." });

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> ObterPorId(Guid id)
        {
            try
            {
                var result = await _clienteService.ObterClientePorId(id);

                if (result == null)
                    return NotFound(new { message = "Não foram encontrados registros." });

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("cliente-com-pedidos/{id}")]
        public async Task<ActionResult<ClienteDto>> ObterClienteComPedidoPorId(Guid id)
        {
            try
            {
                var result = await _clienteService.ObterClientePorIdComPedido(id);

                if (result == null)
                    return NotFound(new { message = "Não foram encontrados registros." });

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> SalvarRegistro([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var result = _clienteService.SavarRegistroDoCliente(clienteDto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ClienteDto>> AlterarRegistro([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var result = _clienteService.AlterarRegistroDoCliente(clienteDto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ClienteDto>> RemoverRegistro(Guid id)
        {
            try
            {
                var result = _clienteService.DeletarRegistroDoCliente(id);

                if (result == null)
                {
                    return Ok("Registro removido com sucesso.");
                }

                return BadRequest(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}