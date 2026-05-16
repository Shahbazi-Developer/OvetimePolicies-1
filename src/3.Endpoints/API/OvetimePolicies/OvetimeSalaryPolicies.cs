namespace OvetimePolicies1.Endpoints.API.OvetimePolicies;

/// <summary>
/// Calculator methods invoked by reflection; names must match allowed overtime calculator names in the API.
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
}
