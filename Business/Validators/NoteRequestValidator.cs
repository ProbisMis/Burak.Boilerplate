using FluentValidation;
using FluentValidation.Results;
using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Utilities.ValidationHelper;

namespace Burak.Boilerplate.Business.Validators
{
    public class NoteRequestValidator : AbstractValidator<BaseCollectionRequest>

    {
        protected override bool PreValidate(ValidationContext<BaseCollectionRequest> context, ValidationResult result)
           => PreValidations.NotNullPreValidation(context, result);

        public NoteRequestValidator()
        {
            RuleFor(r => r.PageSize).NotNull();
        }
    }
}
