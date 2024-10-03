using FluentValidation;
using mySampleBackend.Domain;
namespace mySampleBackend.Validation
{
    public class FloopValidator : AbstractValidator<Floop>
    {
        public FloopValidator()
        {
            RuleFor(x => x.FloopValue)
                .Must(BeGreaterThanZero)
                .WithMessage("Cannot create a floop with value less than Zero");
        }
        private bool BeGreaterThanZero(double value) => value >= 0;
    }
}
