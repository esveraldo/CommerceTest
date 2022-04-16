using CommerceTest.Domain.Entities;
using FluentValidation;

namespace CommerceTeste.Infra.Data.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("O campo usuário é obrigatório.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("O campo senha é obrigatório.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("O campo e confirmação de senha é obrigatório.");
        }
    }
}
