  
using AutoMapper;
using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;
using CommerceTest.Domain.Entities.VOs;
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
            return _mapper.Map<IEnumerable<ClienteDto>>(await _clienteRepository.GetAllAsync());
        }

        public async Task<ClienteDto> ObterClientePorId(Guid id)
        {
            return _mapper.Map<ClienteDto>(await _clienteRepository.GetAsync(id));
        }

        public async Task<ClienteDto> SavarRegistroDoCliente(ClienteDto clienteDto)
        {
            var salvarRegistro = _mapper.Map<Cliente>(clienteDto);

            var endereco = new Endereco(clienteDto.Endereco.Rua, clienteDto.Endereco.Numero, clienteDto.Endereco.Complemento,
                clienteDto.Endereco.Bairro, clienteDto.Endereco.Cidade, clienteDto.Endereco.Estado,
                clienteDto.Endereco.Cep);
            salvarRegistro = new Cliente(clienteDto.Nome, clienteDto.DDD, clienteDto.Telefone, endereco, clienteDto.Documento, clienteDto.UserId);

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
