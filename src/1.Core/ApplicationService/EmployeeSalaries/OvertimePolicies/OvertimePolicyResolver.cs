using System.Reflection;
using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Core.Domain.Exceptions;

namespace OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.OvertimePolicies;

public static class OvertimePolicyResolver
{
    private const string PoliciesAssemblyName = "OvetimePolicies1.Endpoints.API";

    public static decimal GetOvertimeAmount(string calculatorName, decimal basicSalary, decimal allowance)
    {
        var basicAndAllowance = basicSalary + allowance;

        Assembly assembly;
        try
        {
            assembly = LoadPoliciesAssembly();
        }
        catch (FileNotFoundException)
        {
            throw new InvalidEntityStateException(
                TranslatorKeys.VALIDATION_ERROR_NOT_EXIST,
                nameof(calculatorName));
        }

        foreach (var type in assembly.GetExportedTypes())
        {
            var method = type.GetMethod(
                calculatorName,
                BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (method is null)
                continue;

            var result = InvokeCalculator(method, basicSalary, allowance, basicAndAllowance);
            if (result is not null)
                return Convert.ToDecimal(result);
        }

        throw new InvalidEntityStateException(
            TranslatorKeys.VALIDATION_ERROR_NOT_VALID,
            nameof(calculatorName));
    }

    private static Assembly LoadPoliciesAssembly()
    {
        try
        {
            return Assembly.Load(PoliciesAssemblyName);
        }
        catch (FileNotFoundException)
        {
            var path = Path.Combine(AppContext.BaseDirectory, $"{PoliciesAssemblyName}.dll");
            if (File.Exists(path))
                return Assembly.LoadFrom(path);

            throw;
        }
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
