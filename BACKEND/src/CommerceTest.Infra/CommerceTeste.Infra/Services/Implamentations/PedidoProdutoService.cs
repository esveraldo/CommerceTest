using AutoMapper;
using CommerceTest.Domain.Entities;
using CommerceTeste.Infra.Data.Context;
using CommerceTeste.Infra.Services.Contracts;
using CommerceTeste.Infra.UoW.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CommerceTeste.Infra.Services.Implamentations
{
    internal class PedidoProdutoService : IPedidoProdutoService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoProdutoService(ApplicationDbContext applicationDbContext, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Produto> ObterPedidoProdutoPorProdutoId(Guid id)
        {
            return await _applicationDbContext.Produtos.Include(x => x.Pedidos).AsNoTracking()
                                    .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Pedido> ObterPedidoProdutoPorPedidoId(Guid id)
        {
            return await _applicationDbContext.Pedidos.Include(x => x.Produtos).AsNoTracking()
                                    .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Pedido>> ObterTodosOsPedidosComProdutos()
        {
            return await _applicationDbContext.Pedidos.Include(x => x.Produtos).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterTodosOsProdutosComPedidos()
        {
            return await _applicationDbContext.Produtos.Include(x => x.Pedidos).AsNoTracking().ToListAsync();
        }

        public async Task SalvarPedidoProduto(Guid pedidoId, Guid produtoId)
        {
            var novoPedidoProduto = new PedidoProduto(pedidoId, produtoId);
            await _applicationDbContext.AddAsync(novoPedidoProduto);
        }
    }
}
