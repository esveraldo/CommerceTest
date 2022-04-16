using CommerceTest.Application.Dtos;

namespace CommerceTeste.Infra.Services.Contracts
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> ObterTodosOsProdutos();
        Task<ProdutoDto> ObterProdutoPorId(Guid id);
        Task<ProdutoDto> SalvarRegistroDoProduto(ProdutoDto produtoDto);
        Task<ProdutoDto> AlterarRegistroDoProduto(ProdutoDto produtoDto);
        Task<ProdutoDto> DeletarRegistroDoProduto(Guid id);
        
    }
}
