using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using OvetimePolicies1.Endpoints.API.DTOs;

namespace OvetimePolicies1.Endpoints.API.Formatters;

public sealed class CsBodyInputFormatter : TextInputFormatter
{
    public CsBodyInputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/cs"));
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/cs"));
        SupportedEncodings.Add(Encoding.UTF8);
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

        var dto = new EmployeeSalaryCreateDto
        {
            FirstName = ExtractValue(content, nameof(EmployeeSalaryCreateDto.FirstName)),
            LastName = ExtractValue(content, nameof(EmployeeSalaryCreateDto.LastName)),
            BaseSalary = ParseDecimal(ExtractValue(content, nameof(EmployeeSalaryCreateDto.BaseSalary))),
            Date = ParseDate(ExtractValue(content, nameof(EmployeeSalaryCreateDto.Date))),
            AbsorptionAllowance = ParseDecimal(ExtractValue(content, nameof(EmployeeSalaryCreateDto.AbsorptionAllowance))),
            TransportationAllowance = ParseDecimal(ExtractValue(content, nameof(EmployeeSalaryCreateDto.TransportationAllowance))),
            Tax = ParseDecimal(ExtractValue(content, nameof(EmployeeSalaryCreateDto.Tax))),
            OvertimeCalculatorName = ExtractValue(content, nameof(EmployeeSalaryCreateDto.OvertimeCalculatorName))
        };

        return await InputFormatterResult.SuccessAsync(dto);
    }

    private static string ExtractValue(string content, string propertyName)
    {
        var pattern = $@"{propertyName}\s*=\s*""([^""]*)""";
        var match = Regex.Match(content, pattern, RegexOptions.IgnoreCase);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }

    private static decimal ParseDecimal(string value)
        => decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var result) ? result : 0;

    private static DateTime ParseDate(string value)
        => DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)
            ? result
            : DateTime.UtcNow;
}
