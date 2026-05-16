using Microsoft.EntityFrameworkCore;
using OvetimePolicies1.Core.Contracts.EmployeeSalaries.Queries;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.Get;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;
using OvetimePolicies1.Infra.Data.Sql.Queries.Common;
using OvetimePolicies1.Infra.Data.Sql.Queries.EmployeeSalaries.Entities;
using Zamin.Infra.Data.Sql.Queries;

namespace OvetimePolicies1.Infra.Data.Sql.Queries.EmployeeSalaries;

public class EmployeeSalaryRepositrory
    : BaseQueryRepository<OvetimePolicies1QueryDbContext>,
      IEmployeeSalaryQueryRepasitory
{
    public EmployeeSalaryRepositrory(OvetimePolicies1QueryDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<EmployeeSalaryGetQr?> ExecuteAsync(EmployeeSalaryGetQuery query)
    {
        return await _dbContext.Set<EmployeeSalary>()
            .Where(x => !x.Deleted
                        && x.FirstName == query.FirstName
                        && x.LastName == query.LastName
                        && x.Date.Year == query.Date.Year
                        && x.Date.Month == query.Date.Month)
            .Select(x => new EmployeeSalaryGetQr
            {
                Id = x.Id,
                LastName = x.LastName,
                FirstName = x.FirstName,
                BasicSalary = x.BasicSalary,
                Date = x.Date,
                Allowance = x.Allowance,
                Transportation = x.Transportation,
                Tax = x.Tax,
                OvertimeCalculatorName = x.OvertimeCalculatorName,
                OvertimeAmount = x.OvertimeAmount,
                ReceivedSalary = x.ReceivedSalary,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<EmployeeSalaryGetRangeQr>> ExecuteAsync(EmployeeSalaryGetRangeQuery query)
    {
        return await _dbContext.Set<EmployeeSalary>()
            .Where(x => !x.Deleted
                        && x.FirstName == query.FirstName
                        && x.LastName == query.LastName
                        && x.Date >= query.FromDate
                        && x.Date <= query.ToDate)
            .OrderBy(x => x.Date)
            .Select(x => new EmployeeSalaryGetRangeQr
            {
                Id = x.Id,
                LastName = x.LastName,
                FirstName = x.FirstName,
                BasicSalary = x.BasicSalary,
                Date = x.Date,
                Allowance = x.Allowance,
                Transportation = x.Transportation,
                Tax = x.Tax,
                OvertimeCalculatorName = x.OvertimeCalculatorName,
                OvertimeAmount = x.OvertimeAmount,
                ReceivedSalary = x.ReceivedSalary,
            })
            .ToListAsync();
    }
}
