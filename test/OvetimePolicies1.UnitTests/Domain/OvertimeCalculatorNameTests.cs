using OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;
using OvetimePolicies1.SharedKernel.OvetimePolicies;
using Zamin.Core.Domain.Exceptions;

namespace OvetimePolicies1.UnitTests.Domain;

public sealed class OvertimeCalculatorNameTests
{
    [Theory]
    [InlineData("CalcurlatorA")]
    [InlineData("calcURLatorb")]
    public void Constructor_accepts_registered_names_and_normalizes(string input)
    {
        var vo = new OvertimeCalculatorName(input);
        Assert.False(string.IsNullOrEmpty(vo.Value));
        Assert.Equal(OvetimeSalaryPolicies.NormalizeCalculatorName(input), vo.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_rejects_whitespace(string value)
    {
        Assert.Throws<InvalidEntityStateException>(() => new OvertimeCalculatorName(value));
    }

    [Fact]
    public void Constructor_rejects_unknown_calculator()
    {
        Assert.Throws<InvalidEntityStateException>(() => new OvertimeCalculatorName("NotRegisteredX"));
    }

    [Fact]
    public void FromString_behaves_like_constructor_for_valid_name()
    {
        var a = OvertimeCalculatorName.FromString("CalcurlatorC");
        var b = new OvertimeCalculatorName("CalcurlatorC");
        Assert.Equal(a.Value, b.Value);
    }
}
