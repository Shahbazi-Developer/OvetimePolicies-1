using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;

namespace OvetimePolicies1.Infra.Data.Sql.Commands.Common.ValueConverters;

public class DeletedValueConverter : ValueConverter<Deleted, bool>
{
    public DeletedValueConverter() : base(m => m.Value, p => new(p))
    {
    }
}
