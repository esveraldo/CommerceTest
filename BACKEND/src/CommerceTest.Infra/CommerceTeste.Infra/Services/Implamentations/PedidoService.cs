using AutoMapper;
using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;
using CommerceTest.Domain.Entities.Enums;
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
        private readonly IPedidoProdutoService _pedidoProdutoService;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper, IUnitOfWork unitOfWork, IPedidoProdutoService pedidoProdutoService)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _pedidoProdutoService = pedidoProdutoService;
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosOsPedidos()
        {
            return _mapper.Map<IEnumerable<PedidoDto>>(await _pedidoRepository.GetAllAsync());
        }

        public async Task<PedidoDto> ObterPedidoPorId(Guid id)
        {
            return _mapper.Map<PedidoDto>(await _pedidoRepository.GetAsync(id));
        }

        public async Task<PedidoDto> SalvarRegistroDoPedido(PedidoDto pedidoDto)
        {
            _ = _mapper.Map<Pedido>(pedidoDto);

            Pedido? salvarRegistro = new Pedido(pedidoDto.DataDoPedido = DateTime.Now, pedidoDto.ValorTotal, (EStatus)pedidoDto.Status, pedidoDto.Observacoes, pedidoDto.ClienteId)
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var IdPedido = await _pedidoRepository.PostAsync(salvarRegistro);
            await _pedidoProdutoService.SalvarPedidoProduto(IdPedido.Id, Guid.Parse("7C35CC1D-267F-49E8-90B3-81231FF713C1"));
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
            await _pedidoRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return null;
        }
    }
}
