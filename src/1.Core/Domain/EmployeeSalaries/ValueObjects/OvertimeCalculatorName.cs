using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;

public class OvertimeCalculatorName : BaseValueObject<OvertimeCalculatorName>
{
    public const string CalcurlatorA = "CalcurlatorA";
    public const string CalcurlatorB = "CalcurlatorB";
    public const string CalcurlatorC = "CalcurlatorC";

    private static readonly HashSet<string> AllowedValues = new(StringComparer.OrdinalIgnoreCase)
    {
        CalcurlatorA,
        CalcurlatorB,
        CalcurlatorC
    };

    public string Value { get; private set; }

    public static OvertimeCalculatorName FromString(string value)
    {
        return new OvertimeCalculatorName(value);
    }

    public OvertimeCalculatorName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidEntityStateException(
                TranslatorKeys.VALIDATION_ERROR_REQUIRED,
                nameof(OvertimeCalculatorName));
        }

        if (!AllowedValues.Contains(value))
        {
            throw new InvalidEntityStateException(
                TranslatorKeys.VALIDATION_ERROR_NOT_VALID,
                nameof(OvertimeCalculatorName));
        }

        Value = AllowedValues.First(x => x.Equals(value, StringComparison.OrdinalIgnoreCase));
    }

    private OvertimeCalculatorName()
    {
        Value = string.Empty;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator string(OvertimeCalculatorName overtimeCalculatorName)
    {
        return overtimeCalculatorName.Value;
    }

    public static implicit operator OvertimeCalculatorName(string value)
    {
        return new OvertimeCalculatorName(value);
    }
}
