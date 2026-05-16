using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;

namespace OvetimePolicies1.Infra.Data.Sql.Commands.Common.ValueConverters;

public class OvertimeCalculatorNameValueConverter : ValueConverter<OvertimeCalculatorName, string>
{
    public OvertimeCalculatorNameValueConverter() : base(n => n.Value, p => new(p))
    {
    }
}
