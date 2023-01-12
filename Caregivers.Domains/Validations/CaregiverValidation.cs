using FluentValidation;

namespace Caregivers.Domains.Validations
{
    public class CaregiverValidation : AbstractValidator<Caregiver>
    {
        public CaregiverValidation()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.FullName).MaximumLength(100).WithMessage("Full Name may have max  100 characters");
            RuleFor(x => x.Biography).MaximumLength(1000).WithMessage("The Biography may have max 1000 characters");
            RuleFor(x => x.Whatsapp).NotEmpty().WithMessage("Whatsapp is required");
        }
    }
}
