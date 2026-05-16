using Zamin.Core.Domain.ValueObjects;

namespace OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;

public class Deleted : BaseValueObject<Deleted>
{
    public Deleted(bool value)
    {
        Value = value;
    }

    public bool Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Deleted(bool v)
    {
        throw new NotImplementedException();
    }
}
