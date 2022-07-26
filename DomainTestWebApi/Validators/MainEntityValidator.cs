using DomainTestWebApi.Models;
using DomainTestWebApi.Resources;
using FluentValidation;

namespace DomainTestWebApi.Validators
{
    public class MainEntityValidator : AbstractValidator<CreateUpdateMainEntityResource>
    {
        public MainEntityValidator()
        {
            RuleFor(x => x.FirstMainProperty).NotEmpty().WithMessage(ValidationErrorMessages.EmptyModelErrorMessage);
            RuleFor(x => x.SecondMainProperty).NotNull().WithMessage(ValidationErrorMessages.EmptyModelErrorMessage);
            RuleFor(x => x.IntMainProperty).InclusiveBetween(0, 255).WithMessage(ValidationErrorMessages.IntRangeErrorMessage);
            
            //todo: some custom validation could be added as it was discussed
        }
    }
}