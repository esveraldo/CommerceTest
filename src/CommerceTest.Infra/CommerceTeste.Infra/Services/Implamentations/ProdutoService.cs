using AutoMapper;
using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;
using CommerceTeste.Infra.Data.Repositories.Contracts;
using CommerceTeste.Infra.Services.Contracts;
using CommerceTeste.Infra.UoW.Contracts;


namespace CommerceTeste.Infra.Services.Implamentations
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProdutoDto>> ObterTodosOsProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepository.GetAllAsync());
        }

        public async Task<ProdutoDto> ObterProdutoPorId(Guid id)
        {
            return _mapper.Map<ProdutoDto>(await _produtoRepository.GetAsync(id));
        }

        public async Task<ProdutoDto> SalvarRegistroDoProduto(ProdutoDto produtoDto)
        {
            var salvarRegistro = _mapper.Map<Produto>(produtoDto);

            if(salvarRegistro.Nome == produtoDto.Nome)
                return null;

            salvarRegistro.CreatedAt = DateTime.Now;
            salvarRegistro.UpdatedAt = DateTime.Now;
            await _produtoRepository.PostAsync(salvarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return produtoDto;
        }
        public async Task<ProdutoDto> AlterarRegistroDoProduto(ProdutoDto produtoDto)
        {
            var alterarRegistro = _mapper.Map<Produto>(produtoDto);

            var registroParaAlterar = await _produtoRepository.GetAsync(alterarRegistro.Id);
            registroParaAlterar.CreatedAt = alterarRegistro.CreatedAt;
            registroParaAlterar.UpdatedAt = DateTime.UtcNow;
            await _produtoRepository.PutAsync(alterarRegistro);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return produtoDto;
        }

        public async Task<ProdutoDto> DeletarRegistroDoProduto(Guid id)
        {
            await _produtoRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();

            return null;
        }
    }
}
