using FluentValidation;
using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Extensions.Translations.Abstractions;

namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;

public class EmployeeSalaryGetRangeValidation : AbstractValidator<EmployeeSalaryGetRangeQuery>
{
    public EmployeeSalaryGetRangeValidation(ITranslator translator)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.FIRST_NAME]);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.LAST_NAME]);

        RuleFor(x => x.FromDate)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.DATE]);

        RuleFor(x => x.ToDate)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.DATE])
            .GreaterThanOrEqualTo(x => x.FromDate)
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL, TranslatorKeys.DATE]);
    }
}
