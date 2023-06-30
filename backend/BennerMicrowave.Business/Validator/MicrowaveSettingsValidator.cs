using BennerMicrowave.Data.Domain;
using FluentValidation;

namespace BennerMicrowave.Business.Validator
{
    public class MicrowaveSettingsValidator : AbstractValidator<MicrowaveSettings>
    {
        public MicrowaveSettingsValidator()
        {
            RuleFor(x => x.Time).NotEmpty().InclusiveBetween(1, 120).WithMessage("O tempo deve ser um valor entre 1 e 120");
            RuleFor(x => x.Power).NotEmpty().InclusiveBetween(1, 10).WithMessage("A potência deve ser um valor entre 1 e 10");
        }
    }
}
