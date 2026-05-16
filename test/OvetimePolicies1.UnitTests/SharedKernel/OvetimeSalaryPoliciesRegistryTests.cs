using OvetimePolicies1.SharedKernel.OvetimePolicies;

namespace OvetimePolicies1.UnitTests.SharedKernel;

public sealed class OvetimeSalaryPoliciesRegistryTests
{
    [Fact]
    public void GetPoliciesType_resolves_shared_kernel_policy_type()
    {
        var type = OvetimeSalaryPoliciesRegistry.GetPoliciesType();
        Assert.NotNull(type);
        Assert.Same(typeof(OvetimeSalaryPolicies), type);
    }

    [Fact]
    public void GetCalculatorNames_delegates_to_policy_type()
    {
        var fromRegistry = OvetimeSalaryPoliciesRegistry.GetCalculatorNames().OrderBy(x => x, StringComparer.Ordinal).ToArray();
        var direct = OvetimeSalaryPolicies.GetCalculatorNames().OrderBy(x => x, StringComparer.Ordinal).ToArray();
        Assert.Equal(direct, fromRegistry);
    }

    [Theory]
    [InlineData("CalcurlatorA", true)]
    [InlineData("unknown", false)]
    public void IsValidCalculator_matches_policy_rules(string name, bool expected)
    {
        Assert.Equal(expected, OvetimeSalaryPoliciesRegistry.IsValidCalculator(name));
    }
}
