using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Utilities.ValidationHelper;
using FluentValidation;
using FluentValidation.Results;

namespace Burak.Boilerplate.Business.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        protected override bool PreValidate(ValidationContext<UserRequest> context, ValidationResult result)
           => PreValidations.NotNullPreValidation(context, result);

        public UserRequestValidator()
        {
            RuleFor(r => r.Username).NotNull();
        }
    }
}
