using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Utilities.ValidationHelper;
using FluentValidation;
using FluentValidation.Results;

namespace Burak.Boilerplate.Business.Validators
{
    public class PurchaseRequestValidator : AbstractValidator<PurchaseRequestModel>
    {
        protected override bool PreValidate(ValidationContext<PurchaseRequestModel> context, ValidationResult result)
           => PreValidations.NotNullPreValidation(context, result);

        public PurchaseRequestValidator()
        {
            RuleFor(r => r.CustomerId).NotNull();
            RuleFor(r => r.PurchaseTotal).NotNull();
            RuleFor(r => r.Items).NotEmpty().NotNull();
        }
    }
}
