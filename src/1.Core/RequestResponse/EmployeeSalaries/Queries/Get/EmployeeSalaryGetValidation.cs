using FluentValidation;
using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Extensions.Translations.Abstractions;

namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.Get;

public class EmployeeSalaryGetValidation : AbstractValidator<EmployeeSalaryGetQuery>
{
    public EmployeeSalaryGetValidation(ITranslator translator)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.FIRST_NAME]);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.LAST_NAME]);

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.DATE]);
    }
}
