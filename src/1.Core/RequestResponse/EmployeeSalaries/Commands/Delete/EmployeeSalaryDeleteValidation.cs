using FluentValidation;
using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Extensions.Translations.Abstractions;

namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Delete;

public class EmployeeSalaryDeleteValidation : AbstractValidator<EmployeeSalaryDeleteCommand>
{
    public EmployeeSalaryDeleteValidation(ITranslator translator)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.FIRST_NAME]);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.LAST_NAME]);

        RuleFor(x => x.Date)
            .Must(d => d != default)
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.DATE]);
    }
}
