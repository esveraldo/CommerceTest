using CommerceTest.Application.Dtos;
using CommerceTeste.Infra.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommerceTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<ClientesController> _logger;

        public UsersController(IUserService userService, ILogger<ClientesController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> ObterTodos()
        {
            try
            {
                var result = await _userService.ObterTodosOsUsuarios();

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
        public async Task<ActionResult<UserDto>> ObterPorId(Guid id)
        {
            try
            {
                var result = await _userService.ObterUsuarioPorId(id);

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
        public async Task<ActionResult<UserDto>> SalvarRegistro([FromBody] UserDto userDto)
        {
            try
            {
                var result = _userService.SalvarRegistroDoUsuario(userDto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> AlterarRegistro([FromBody] UserDto userDto)
        {
            try
            {
                var result = _userService.AlterarRegistroDoUsuario(userDto);
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
                var result = _userService.DeletarRegistroDoUsuario(id);

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
