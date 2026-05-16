using OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.OvertimePolicies;
using Zamin.Core.Domain.Exceptions;

namespace OvetimePolicies1.UnitTests.ApplicationService;

/// <summary>
/// Exercises <see cref="OvertimePolicyResolver"/> against <see cref="OvetimePolicies1.SharedKernel.OvetimePolicies.OvetimeSalaryPolicies"/>.
/// </summary>
public sealed class OvertimePolicyResolverTests
{
    [Theory]
    [InlineData("CalcurlatorA", 1000, 500, 150)]
    [InlineData("calcURLatora", 200, 50, 25)]
    [InlineData("CalcurlatorB", 100, 0, 20)]
    [InlineData("CalcurlatorC", 1000, 0, 150)]
    public void GetOvertimeAmount_returns_expected_for_registered_calculator(
        string name,
        decimal basic,
        decimal allowance,
        decimal expected)
    {
        var actual = OvertimePolicyResolver.GetOvertimeAmount(name, basic, allowance);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("NoSuchCalculator")]
    public void GetOvertimeAmount_throws_when_calculator_invalid(string? name)
    {
        var ex = Assert.Throws<InvalidEntityStateException>(() =>
            OvertimePolicyResolver.GetOvertimeAmount(name!, 100, 50));
        Assert.NotNull(ex);
    }
}
