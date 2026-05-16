using Zamin.Core.RequestResponse.Queries;

namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.Get;

public sealed class EmployeeSalaryGetQuery : IQuery<EmployeeSalaryGetQr>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime Date { get; set; }
}
