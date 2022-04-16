using AutoMapper;
using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;
using CommerceTeste.Infra.Data.Repositories.Contracts;
using CommerceTeste.Infra.Services.Contracts;
using CommerceTeste.Infra.UoW.Contracts;

namespace CommerceTeste.Infra.Services.Implamentations
{
    public class PedidoProdutoService : IPedidoProdutoService
    {
        private readonly IPedidoProdutoRepository _pedidoProdutoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoProdutoService(IPedidoProdutoRepository pedidoProdutoRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _pedidoProdutoRepository = pedidoProdutoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PedidoProdutoDto>> ObterTodosOsPedidoProdutos()
        {
            return _mapper.Map<IEnumerable<PedidoProdutoDto>>(_pedidoProdutoRepository.GetAllAsync());
        }
        public async Task<PedidoProdutoDto> ObterPedidosProdutosPorId(Guid id)
        {
            return _mapper.Map<PedidoProdutoDto>(_pedidoProdutoRepository.GetAsync(id));
        }

        public async Task<PedidoProdutoDto> SalvarRegistroDoPedidoProduto(PedidoProdutoDto pedidoProdutoDto)
        {
            var salvarRegistro = _mapper.Map<PedidoProduto>(pedidoProdutoDto); 

            salvarRegistro.CreatedAt = DateTime.Now;
            salvarRegistro.UpdatedAt = DateTime.Now;
            await _pedidoProdutoRepository.PostAsync(salvarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return pedidoProdutoDto;
        }
        public async Task<PedidoProdutoDto> AlterarRegistroDoPedidoPedidosProduto(PedidoProdutoDto pedidoProdutoDto)
        {
            var alterarRegistro = _mapper.Map<PedidoProduto>(pedidoProdutoDto);

            var registroParaAlterar = await _pedidoProdutoRepository.GetAsync(alterarRegistro.Id);
            registroParaAlterar.CreatedAt = alterarRegistro.CreatedAt;
            registroParaAlterar.UpdatedAt = DateTime.UtcNow;
            await _pedidoProdutoRepository.PutAsync(alterarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return pedidoProdutoDto;
        }

        public async Task<PedidoProdutoDto> DeletarRegistroDoPedidoPedidosProduto(Guid id)
        {
            await _pedidoProdutoRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return null;
        }
    }
}
