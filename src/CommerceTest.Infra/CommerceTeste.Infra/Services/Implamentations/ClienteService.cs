
using AutoMapper;
using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;
using CommerceTeste.Infra.Data.Repositories.Contracts;
using CommerceTeste.Infra.Services.Contracts;
using CommerceTeste.Infra.UoW.Contracts;

namespace CommerceTeste.Infra.Services.Implamentations
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClienteDto>> ObterTodosOsClientes()
        {
            return _mapper.Map<IEnumerable<ClienteDto>>(_clienteRepository.GetAllAsync());
        }

        public async Task<ClienteDto> ObterClientePorId(Guid id)
        {
            return _mapper.Map<ClienteDto>(_clienteRepository.GetAsync(id));
        }

        public async Task<ClienteDto> SavarRegistroDoCliente(ClienteDto clienteDto)
        {
            var salvarRegistro = _mapper.Map<Cliente>(clienteDto);

            if (salvarRegistro.Nome == clienteDto.Nome)
                return null;

            salvarRegistro.CreatedAt = DateTime.Now;
            salvarRegistro.UpdatedAt = DateTime.Now;
            await _clienteRepository.PostAsync(salvarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return clienteDto;
        }

        public async Task<ClienteDto> AlterarRegistroDoCliente(ClienteDto clienteDto)
        {
            var alterarRegistro = _mapper.Map<Cliente>(clienteDto);

            var clienteExistente = await _clienteRepository.GetAsync(alterarRegistro.Id);

            alterarRegistro.CreatedAt = clienteExistente.CreatedAt;
            alterarRegistro.UpdatedAt = DateTime.Now;
            await _clienteRepository.PostAsync(alterarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return clienteDto;
        }

        public async Task<ClienteDto> DeletarRegistroDoCliente(Guid id)
        {
            await _clienteRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return null;
        }
    }
}
