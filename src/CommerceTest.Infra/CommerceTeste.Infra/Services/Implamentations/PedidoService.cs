using AutoMapper;
using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;
using CommerceTeste.Infra.Data.Repositories.Contracts;
using CommerceTeste.Infra.Services.Contracts;
using CommerceTeste.Infra.UoW.Contracts;

namespace CommerceTeste.Infra.Services.Implamentations
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosOsPedidos()
        {
            return _mapper.Map<IEnumerable<PedidoDto>>(_pedidoRepository.GetAllAsync());
        }

        public async Task<PedidoDto> ObterPedidoPorId(Guid id)
        {
            return _mapper.Map<PedidoDto>(_pedidoRepository.GetAsync(id));
        }

        public async Task<PedidoDto> SalvarRegistroDoPedido(PedidoDto pedidoDto)
        {
            var salvarRegistro = _mapper.Map<Pedido>(pedidoDto);
            
            salvarRegistro.CreatedAt = DateTime.Now;
            salvarRegistro.UpdatedAt = DateTime.Now;
            await _pedidoRepository.PostAsync(salvarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return pedidoDto;
        }

        public async Task<PedidoDto> AlterarRegistroDoPedido(PedidoDto pedidoDto)
        {
            var alterarRegistro = _mapper.Map<Pedido>(pedidoDto);

            var registroParaAlterar = await _pedidoRepository.GetAsync(alterarRegistro.Id);
            alterarRegistro.CreatedAt = registroParaAlterar.CreatedAt;
            alterarRegistro.UpdatedAt = DateTime.UtcNow;
            await _pedidoRepository.PutAsync(alterarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return pedidoDto;
        }

        public async Task<PedidoDto> DeletarRegistroDoPedido(Guid id)
        {
            _pedidoRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return null;
        }
    }
}
