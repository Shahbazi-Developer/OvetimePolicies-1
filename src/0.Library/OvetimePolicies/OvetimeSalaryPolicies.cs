namespace OvetimePolicies;

/// <summary>
/// Calculator methods invoked by reflection; names must match allowed overtime calculator names in the API.
/// Signature: base salary, absorption allowance, sum of both — replace this assembly with your assignment DLL if formulas differ.
/// </summary>
public static class OvetimeSalaryPolicies
{
    public static decimal CalcurlatorA(decimal baseSalary, decimal absorptionAllowance, decimal baseAndAbsorptionSum) =>
        baseAndAbsorptionSum * 0.1m;

    public static decimal CalcurlatorB(decimal baseSalary, decimal absorptionAllowance, decimal baseAndAbsorptionSum) =>
        baseAndAbsorptionSum * 0.2m;

    public static decimal CalcurlatorC(decimal baseSalary, decimal absorptionAllowance, decimal baseAndAbsorptionSum) =>
        baseAndAbsorptionSum * 0.15m;
}
