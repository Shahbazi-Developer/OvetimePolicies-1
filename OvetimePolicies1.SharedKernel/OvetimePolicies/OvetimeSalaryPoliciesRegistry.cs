using System.Reflection;

namespace OvetimePolicies1.SharedKernel.OvetimePolicies;

/// <summary>
/// Runtime access to <c>OvetimeSalaryPolicies</c> from layers that cannot reference the API project.
/// </summary>
public static class OvetimeSalaryPoliciesRegistry
{
    private const string PoliciesAssemblyName = "OvetimePolicies1.Endpoints.API";
    private const string PoliciesTypeFullName = "OvetimePolicies1.Endpoints.API.OvetimePolicies.OvetimeSalaryPolicies";

    private static readonly Lazy<Type?> PoliciesTypeLazy = new(LoadPoliciesType);

    public static Type? GetPoliciesType() => PoliciesTypeLazy.Value;

    public static IReadOnlyCollection<string> GetCalculatorNames()
    {
        var type = PoliciesTypeLazy.Value;
        if (type is null)
            return Array.Empty<string>();

        var method = type.GetMethod(
            nameof(GetCalculatorNames),
            BindingFlags.Public | BindingFlags.Static,
            Type.EmptyTypes);

        return method?.Invoke(null, null) as IReadOnlyCollection<string> ?? Array.Empty<string>();
    }

    public static bool IsValidCalculator(string? name)
    {
        var type = PoliciesTypeLazy.Value;
        if (type is null || string.IsNullOrWhiteSpace(name))
            return false;

        var method = type.GetMethod(
            nameof(IsValidCalculator),
            BindingFlags.Public | BindingFlags.Static,
            [typeof(string)]);

        return method?.Invoke(null, [name]) is true;
    }

    public static string? NormalizeCalculatorName(string name)
    {
        var type = PoliciesTypeLazy.Value;
        if (type is null)
            return null;

        var method = type.GetMethod(
            nameof(NormalizeCalculatorName),
            BindingFlags.Public | BindingFlags.Static,
            [typeof(string)]);

        return method?.Invoke(null, [name]) as string;
    }

    private static Type? LoadPoliciesType()
    {
        try
        {
            var assembly = Assembly.Load(PoliciesAssemblyName);
            return assembly.GetType(PoliciesTypeFullName, throwOnError: false);
        }
        catch (FileNotFoundException)
        {
            var path = Path.Combine(AppContext.BaseDirectory, $"{PoliciesAssemblyName}.dll");
            if (!File.Exists(path))
                return null;

            var assembly = Assembly.LoadFrom(path);
            return assembly.GetType(PoliciesTypeFullName, throwOnError: false);
        }
    }
}
