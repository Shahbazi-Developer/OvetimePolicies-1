using System.Reflection;

namespace OvetimePolicies1.SharedKernel.OvetimePolicies;

/// <summary>
/// Calculator methods invoked by reflection from <see cref="OvetimeSalaryPoliciesRegistry"/>.
/// Signature: basic salary, allowance, sum of both.
/// </summary>
public static class OvetimeSalaryPolicies
{
    public static decimal CalcurlatorA(decimal basicSalary, decimal allowance, decimal basicAndAllowanceSum) =>
        basicAndAllowanceSum * 0.1m;

    public static decimal CalcurlatorB(decimal basicSalary, decimal allowance, decimal basicAndAllowanceSum) =>
        basicAndAllowanceSum * 0.2m;

    public static decimal CalcurlatorC(decimal basicSalary, decimal allowance, decimal basicAndAllowanceSum) =>
        basicAndAllowanceSum * 0.15m;

    public static IReadOnlyCollection<string> GetCalculatorNames() =>
        typeof(OvetimeSalaryPolicies)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.ReturnType == typeof(decimal) && m.GetParameters().Length > 0)
            .Select(m => m.Name)
            .ToArray();

    public static bool IsValidCalculator(string? name) =>
        !string.IsNullOrWhiteSpace(name) &&
        GetCalculatorNames().Contains(name, StringComparer.OrdinalIgnoreCase);

    public static string NormalizeCalculatorName(string name) =>
        GetCalculatorNames().First(x => x.Equals(name, StringComparison.OrdinalIgnoreCase));
}
