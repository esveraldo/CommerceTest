using AutoMapper;
using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;
using CommerceTeste.Infra.Data.Repositories.Contracts;
using CommerceTeste.Infra.Services.Contracts;
using CommerceTeste.Infra.UoW.Contracts;

namespace CommerceTeste.Infra.Services.Implamentations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserDto>> ObterTodosOsUsuarios()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserDto> ObterUsuarioPorId(Guid id)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetAsync(id));
        }

        public async Task<UserDto> SalvarRegistroDoUsuario(UserDto userDto)
        {
            var salvarRegistro = _mapper.Map<User>(userDto);

            salvarRegistro = new User(userDto.UserName, userDto.Password);

            salvarRegistro.CreatedAt = DateTime.Now;
            salvarRegistro.UpdatedAt = DateTime.Now;
            await _userRepository.PostAsync(salvarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return userDto;
        }

        public async Task<UserDto> AlterarRegistroDoUsuario(UserDto userDto)
        {
            var alterarRegistro = _mapper.Map<User>(userDto);

            var registroParaAlterar = await _userRepository.GetAsync(alterarRegistro.Id);
            registroParaAlterar.CreatedAt = alterarRegistro.CreatedAt;
            registroParaAlterar.UpdatedAt = DateTime.UtcNow;
            await _userRepository.PutAsync(alterarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return userDto;
        }

        public async Task<UserDto> DeletarRegistroDoUsuario(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return null;
        }
    }
}
