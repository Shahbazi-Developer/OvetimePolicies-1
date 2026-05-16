using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using OvetimePolicies1.Endpoints.API.DTOs;

namespace OvetimePolicies1.Endpoints.API.Formatters;

public sealed class CustomBodyInputFormatter : TextInputFormatter
{
    public CustomBodyInputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/custom"));
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/custom"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    public override bool CanRead(InputFormatterContext context)
    {
        return base.CanRead(context) && context.ModelType == typeof(EmployeeSalaryCreateDto);
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(
        InputFormatterContext context,
        Encoding encoding)
    {
        using var reader = new StreamReader(context.HttpContext.Request.Body, encoding);
        var content = await reader.ReadToEndAsync();

        if (string.IsNullOrWhiteSpace(content))
            return await InputFormatterResult.FailureAsync();

        var lines = content.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (lines.Length < 2)
            return await InputFormatterResult.FailureAsync();

        var headers = lines[0].Split('/', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var values = lines[1].Split('/', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (headers.Length != values.Length)
            return await InputFormatterResult.FailureAsync();

        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < headers.Length; i++)
            map[headers[i]] = values[i];

        var dto = new EmployeeSalaryCreateDto
        {
            FirstName = GetValue(map, "FirstName", "نام"),
            LastName = GetValue(map, "LastName", "نام خانوادگی"),
            BaseSalary = ParseDecimal(GetValue(map, "BaseSalary", "حقوق پایه")),
            Date = ParseDate(GetValue(map, "Date", "تاریخ")),
            AbsorptionAllowance = ParseDecimal(GetValue(map, "AbsorptionAllowance", "حق جذب")),
            TransportationAllowance = ParseDecimal(GetValue(map, "TransportationAllowance", "ایاب و ذهاب")),
            Tax = ParseDecimal(GetValue(map, "Tax", "مالیات")),
            OvertimeCalculatorName = GetValue(map, "OvertimeCalculatorName", "OverTimeCalculator")
        };

        return await InputFormatterResult.SuccessAsync(dto);
    }

    private static string GetValue(IReadOnlyDictionary<string, string> map, params string[] keys)
    {
        foreach (var key in keys)
        {
            if (map.TryGetValue(key, out var value))
                return value;
        }

        return string.Empty;
    }

    private static decimal ParseDecimal(string value)
        => decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var result) ? result : 0;

    private static DateTime ParseDate(string value)
        => DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)
            ? result
            : DateTime.UtcNow;
}
