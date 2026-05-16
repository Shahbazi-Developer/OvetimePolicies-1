using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.Get;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;
using Zamin.Core.Contracts.Data.Queries;

namespace OvetimePolicies1.Core.Contracts.EmployeeSalaries.Queries;

public interface IEmployeeSalaryQueryRepasitory : IQueryRepository
{
    Task<EmployeeSalaryGetQr?> ExecuteAsync(EmployeeSalaryGetQuery query);
    Task<List<EmployeeSalaryGetRangeQr>> ExecuteAsync(EmployeeSalaryGetRangeQuery query);
}
