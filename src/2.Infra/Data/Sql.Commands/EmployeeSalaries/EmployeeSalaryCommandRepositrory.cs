using Microsoft.EntityFrameworkCore;
using OvetimePolicies1.Core.Contracts.EmployeeSalaries.Command;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.Entities;
using OvetimePolicies1.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace OvetimePolicies1.Infra.Data.Sql.Commands.EmployeeSalaries;

public class EmployeeSalaryCommandRepositrory
    : BaseCommandRepository<EmployeeSalary, OvetimePolicies1CommandDbContext, int>,
      IEmployeeSalaryCommandRepasitory
{
    public EmployeeSalaryCommandRepositrory(OvetimePolicies1CommandDbContext dbContext) : base(dbContext)
    {
    }

    public Task<EmployeeSalary?> GetByPersonAndMonthAsync(
        string firstName,
        string lastName,
        DateTime date,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<EmployeeSalary>()
            .FirstOrDefaultAsync(
                x => !x.Deleted.Value
                     && x.FirstName == firstName
                     && x.LastName == lastName
                     && x.Date.Year == date.Year
                     && x.Date.Month == date.Month,
                cancellationToken);
    }
}
