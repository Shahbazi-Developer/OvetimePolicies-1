using OvetimePolicies1.Core.Contracts.EmployeeSalaries.Queries;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.Get;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.Queries.Get;

public sealed class EmployeeSalaryGetQueryHandler : QueryHandler<EmployeeSalaryGetQuery, EmployeeSalaryGetQr>
{
    private readonly IEmployeeSalaryQueryRepasitory _employeeSalaryQueryRepasitory;

    public EmployeeSalaryGetQueryHandler(ZaminServices zaminServices,
                                         IEmployeeSalaryQueryRepasitory employeeSalaryQueryRepasitory) : base(zaminServices)
    {
        _employeeSalaryQueryRepasitory = employeeSalaryQueryRepasitory;
    }

    public override async Task<QueryResult<EmployeeSalaryGetQr>> Handle(EmployeeSalaryGetQuery query)
    {
        return Result(await _employeeSalaryQueryRepasitory.ExecuteAsync(query));
    }
}
