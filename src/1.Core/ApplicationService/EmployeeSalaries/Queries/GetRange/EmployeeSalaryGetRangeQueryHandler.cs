using OvetimePolicies1.Core.Contracts.EmployeeSalaries.Queries;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.Queries.GetRange;

public sealed class EmployeeSalaryGetRangeQueryHandler : QueryHandler<EmployeeSalaryGetRangeQuery, List<EmployeeSalaryGetRangeQr>>
{
    private readonly IEmployeeSalaryQueryRepasitory _employeeSalaryQueryRepasitory;

    public EmployeeSalaryGetRangeQueryHandler(
        ZaminServices zaminServices,
        IEmployeeSalaryQueryRepasitory employeeSalaryQueryRepasitory) : base(zaminServices)
    {
        _employeeSalaryQueryRepasitory = employeeSalaryQueryRepasitory;
    }

    public override async Task<QueryResult<List<EmployeeSalaryGetRangeQr>>> Handle(EmployeeSalaryGetRangeQuery query)
    {
        return Result(await _employeeSalaryQueryRepasitory.ExecuteAsync(query));
    }
}
