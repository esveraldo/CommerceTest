using CommerceTest.Domain.Entities;
using FluentValidation;

namespace CommerceTeste.Infra.Data.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .Length(3, 100).WithMessage("O nome deve ter entre {minlength} e {maxlength} caracteres.");

            RuleFor(x => x.DDD)
                .NotEmpty().WithMessage("O campo DDD é obrigatório.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O campo telefone é obrigatório.");

            RuleFor(x => x.Endereco.Rua)
                .NotEmpty().WithMessage("O campo rua é obrigatório.");

            RuleFor(x => x.Endereco.Numero)
                .NotEmpty().WithMessage("O campo número é obrigatório.");

            RuleFor(x => x.Endereco.Bairro)
                .NotEmpty().WithMessage("O campo bairro é obrigatório.");

            RuleFor(x => x.Endereco.Cidade)
                .NotEmpty().WithMessage("O campo cidade é obrigatório.");

            RuleFor(x => x.Endereco.Estado)
                .NotEmpty().WithMessage("O campo estado é obrigatório.");

            RuleFor(x => x.Endereco.Cep)
                .NotEmpty().WithMessage("O campo cep é obrigatório.");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("O campo documentos é obrigatório.");
        }
    }
}
