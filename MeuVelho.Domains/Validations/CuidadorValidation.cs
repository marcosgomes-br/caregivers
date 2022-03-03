using FluentValidation;

namespace MeuVelho.Domains.Validations
{
    public class CuidadorValidation : AbstractValidator<CuidadorDomain>
    {
        public CuidadorValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é um campo obrigatório");
            RuleFor(x => x.Nome).MaximumLength(100).WithMessage("O Nome poderá ter até 100 caracteres");
            RuleFor(x => x.Biografia).MaximumLength(1000).WithMessage("A Biografia poderá ter até 1000 caracteres");
            RuleFor(x => x.Whatsapp).NotEmpty().WithMessage("Whatsapp é um campo obrigatório");
        }
    }
}
