using OvetimePolicies1.SharedKernel.OvetimePolicies;

namespace OvetimePolicies1.UnitTests.SharedKernel;

public sealed class OvetimeSalaryPoliciesTests
{
    [Theory]
    [InlineData(1000, 500, 150)] // (1000+500)*0.1
    [InlineData(0, 0, 0)]
    [InlineData(10.5, 2.5, 1.3)] // 13 * 0.1
    public void CalcurlatorA_returns_ten_percent_of_basic_plus_allowance(
        decimal basic,
        decimal allowance,
        decimal expected)
    {
        var sum = basic + allowance;
        var actual = OvetimeSalaryPolicies.CalcurlatorA(basic, allowance, sum);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1000, 500, 300)]
    [InlineData(50, 50, 20)]
    public void CalcurlatorB_returns_twenty_percent_of_sum(decimal basic, decimal allowance, decimal expected)
    {
        var sum = basic + allowance;
        var actual = OvetimeSalaryPolicies.CalcurlatorB(basic, allowance, sum);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1000, 500, 225)]
    public void CalcurlatorC_returns_fifteen_percent_of_sum(decimal basic, decimal allowance, decimal expected)
    {
        var sum = basic + allowance;
        var actual = OvetimeSalaryPolicies.CalcurlatorC(basic, allowance, sum);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetCalculatorNames_includes_policy_methods_and_excludes_helpers()
    {
        var names = OvetimeSalaryPolicies.GetCalculatorNames().ToHashSet(StringComparer.Ordinal);
        Assert.Contains("CalcurlatorA", names);
        Assert.Contains("CalcurlatorB", names);
        Assert.Contains("CalcurlatorC", names);
        Assert.DoesNotContain("GetCalculatorNames", names);
        Assert.DoesNotContain("IsValidCalculator", names);
        Assert.DoesNotContain("NormalizeCalculatorName", names);
    }

    [Theory]
    [InlineData("CalcurlatorA", true)]
    [InlineData("calcURLatora", true)]
    [InlineData("CalcurlatorB", true)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    [InlineData("Unknown", false)]
    public void IsValidCalculator_expected(string? name, bool expected)
    {
        Assert.Equal(expected, OvetimeSalaryPolicies.IsValidCalculator(name));
    }

    [Theory]
    [InlineData("calcURLatorb", "CalcurlatorB")]
    [InlineData("CALCURLATORC", "CalcurlatorC")]
    public void NormalizeCalculatorName_returns_canonical_spelling(string input, string expected)
    {
        Assert.Equal(expected, OvetimeSalaryPolicies.NormalizeCalculatorName(input));
    }
}
