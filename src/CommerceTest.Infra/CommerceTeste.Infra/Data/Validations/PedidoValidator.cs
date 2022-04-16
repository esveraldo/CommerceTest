using CommerceTest.Domain.Entities;
using FluentValidation;

namespace CommerceTeste.Infra.Data.Validations
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(x => x.DataDoPedido)
                .NotEmpty().WithMessage("O campo data é obrigatório.");

            RuleFor(x => x.ValorTotal)
                .NotEmpty().WithMessage("O campo valor total é obrigatório.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("O campo status do pedido é obrigatório.");
        }
    }
}
