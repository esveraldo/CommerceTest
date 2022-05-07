using CommerceTest.Application.Dtos;

namespace CommerceTeste.Infra.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> ObterTodosOsUsuarios();
        Task<UserDto> ObterUsuarioPorId(Guid id);
        Task<UserDto> SalvarRegistroDoUsuario(UserDto userDto);
        Task<UserDto> AlterarRegistroDoUsuario(UserDto userDto);
        Task<UserDto> DeletarRegistroDoUsuario(Guid id);
        bool ValidaSenha(string user, string pass);
    }
}
