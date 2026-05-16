using System.Reflection;
using OvetimePolicies1.SharedKernel.OvetimePolicies;
using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Core.Domain.Exceptions;

namespace OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.OvertimePolicies;

public static class OvertimePolicyResolver
{
    public static decimal GetOvertimeAmount(string calculatorName, decimal basicSalary, decimal allowance)
    {
        if (!OvetimeSalaryPoliciesRegistry.IsValidCalculator(calculatorName))
        {
            throw new InvalidEntityStateException(
                TranslatorKeys.VALIDATION_ERROR_NOT_VALID,
                nameof(calculatorName));
        }

        var basicAndAllowance = basicSalary + allowance;
        var policiesType = OvetimeSalaryPoliciesRegistry.GetPoliciesType();

        if (policiesType is null)
        {
            throw new InvalidEntityStateException(
                TranslatorKeys.VALIDATION_ERROR_NOT_EXIST,
                nameof(calculatorName));
        }

        var method = policiesType.GetMethod(
            calculatorName,
            BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);

        if (method is null)
        {
            throw new InvalidEntityStateException(
                TranslatorKeys.VALIDATION_ERROR_NOT_VALID,
                nameof(calculatorName));
        }

        var result = InvokeCalculator(method, basicSalary, allowance, basicAndAllowance);
        if (result is null)
        {
            throw new InvalidEntityStateException(
                TranslatorKeys.VALIDATION_ERROR_NOT_VALID,
                nameof(calculatorName));
        }

        return Convert.ToDecimal(result);
    }

    private static object? InvokeCalculator(
        MethodInfo method,
        decimal basicSalary,
        decimal allowance,
        decimal basicAndAllowance)
    {
        var parameters = method.GetParameters();
        var instance = method.IsStatic ? null : Activator.CreateInstance(method.DeclaringType!);

        return parameters.Length switch
        {
            0 => method.Invoke(instance, null),
            1 when parameters[0].ParameterType == typeof(decimal) => method.Invoke(instance, [basicAndAllowance]),
            2 when parameters[0].ParameterType == typeof(decimal) && parameters[1].ParameterType == typeof(decimal)
                => method.Invoke(instance, [basicSalary, allowance]),
            3 when AllDecimals(parameters)
                => method.Invoke(instance, [basicSalary, allowance, basicAndAllowance]),
            _ => null
        };
    }

    private static bool AllDecimals(ParameterInfo[] parameters) =>
        parameters is [{ ParameterType: var p0 }, { ParameterType: var p1 }, { ParameterType: var p2 }] &&
        p0 == typeof(decimal) && p1 == typeof(decimal) && p2 == typeof(decimal);
}
