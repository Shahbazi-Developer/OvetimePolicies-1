using Zamin.Core.RequestResponse.Queries;

namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;

public sealed class EmployeeSalaryGetRangeQuery : IQuery<List<EmployeeSalaryGetRangeQr>>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}
