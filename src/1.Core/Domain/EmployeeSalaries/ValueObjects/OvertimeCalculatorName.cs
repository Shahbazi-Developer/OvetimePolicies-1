using OvetimePolicies1.SharedKernel.OvetimePolicies;
using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;

public class OvertimeCalculatorName : BaseValueObject<OvertimeCalculatorName>
{
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

        if (!OvetimeSalaryPoliciesRegistry.IsValidCalculator(value))
        {
            throw new InvalidEntityStateException(
                TranslatorKeys.VALIDATION_ERROR_NOT_VALID,
                nameof(OvertimeCalculatorName));
        }

        Value = OvetimeSalaryPoliciesRegistry.NormalizeCalculatorName(value) ?? value;
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
