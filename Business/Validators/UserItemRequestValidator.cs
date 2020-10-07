using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Utilities.ValidationHelper;
using FluentValidation;
using FluentValidation.Results;

namespace Burak.Boilerplate.Business.Validators
{
    public class UserItemRequestValidator : AbstractValidator<UserItemRequest>
    {
        protected override bool PreValidate(ValidationContext<UserItemRequest> context, ValidationResult result)
            => PreValidations.NotNullPreValidation(context, result);

        public UserItemRequestValidator()
        {
            RuleFor(r => r.ItemId).NotNull();
            RuleFor(r => r.UserId).NotNull();
            RuleFor(r => r.ItemLevel).NotEmpty().NotNull();
            RuleFor(r => r.Quantity).NotEmpty().NotNull();
        }
    }
}