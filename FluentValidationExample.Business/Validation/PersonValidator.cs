using FluentValidation;
using FluentValidationExample.Business.Models.Public;

namespace FluentValidationExample.Business.Validation
{
    internal class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(dto => dto.First)
                .NotEmpty()
                .Must(CheckFirst).WithMessage("no 'a' allowed");

            RuleFor(dto => dto.Last)
                .NotEmpty();
        }

        private bool CheckFirst(string value)
        {
            return !value.Contains("a");
        }
    }
}