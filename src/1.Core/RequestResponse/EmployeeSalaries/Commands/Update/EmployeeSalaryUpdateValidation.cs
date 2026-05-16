using FluentValidation;
using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Extensions.Translations.Abstractions;

namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Update;

public sealed class EmployeeSalaryUpdateValidation : AbstractValidator<EmployeeSalaryUpdateCommand>
{
    private static readonly string[] AllowedCalculators = ["CalcurlatorA", "CalcurlatorB", "CalcurlatorC"];

    public EmployeeSalaryUpdateValidation(ITranslator translator)
    {
        RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.FIRST_NAME])
            .MinimumLength(MaxLengthConfiguration.NAME_MIN_LENGTH)
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_STRING_MIN_LENGTH, TranslatorKeys.FIRST_NAME, MaxLengthConfiguration.NAME_MIN_LENGTH.ToString()])
            .MaximumLength(MaxLengthConfiguration.NAME_MAX_LENGTH)
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_STRING_MAX_LENGTH, TranslatorKeys.FIRST_NAME, MaxLengthConfiguration.NAME_MAX_LENGTH.ToString()]);

        RuleFor(x => x.LastName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.LAST_NAME])
            .MinimumLength(MaxLengthConfiguration.NAME_MIN_LENGTH)
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_STRING_MIN_LENGTH, TranslatorKeys.LAST_NAME, MaxLengthConfiguration.NAME_MIN_LENGTH.ToString()])
            .MaximumLength(MaxLengthConfiguration.NAME_MAX_LENGTH)
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_STRING_MAX_LENGTH, TranslatorKeys.LAST_NAME, MaxLengthConfiguration.NAME_MAX_LENGTH.ToString()]);

        RuleFor(x => x.BasicSalary)
            .GreaterThanOrEqualTo(MaxLengthConfiguration.PRICE_MIN_VALUE)
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN, TranslatorKeys.BASIC_SALARY]);

        RuleFor(x => x.Date)
            .Must(date => date != default)
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.DATE]);

        RuleFor(x => x.OvertimeCalculatorName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_REQUIRED, TranslatorKeys.OVERTIME_CALCULATOR_NAME])
            .Must(name => AllowedCalculators.Contains(name, StringComparer.OrdinalIgnoreCase))
            .WithMessage(translator[TranslatorKeys.VALIDATION_ERROR_NOT_VALID, TranslatorKeys.OVERTIME_CALCULATOR_NAME]);
    }
}
