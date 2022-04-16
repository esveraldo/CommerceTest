using CommerceTest.Domain.Entities;
using FluentValidation;

namespace CommerceTeste.Infra.Data.Validations
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo nome do produto é obrigatório.");

            RuleFor(x => x.Preco)
                .NotEmpty().WithMessage("O campo Preço é obrigatório.")
                .Must(x => x > 0).WithMessage("O preço tem que ser maior que zero.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo descrição é obrigatório.");
        }
    }
}
