using OvetimePolicies1.Core.Domain.EmployeeSalaries.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace OvetimePolicies1.Core.Contracts.EmployeeSalaries.Command;

public interface IEmployeeSalaryCommandRepasitory : ICommandRepository<EmployeeSalary, int>
{
    Task<EmployeeSalary?> GetByPersonAndMonthAsync(
        string firstName,
        string lastName,
        DateTime date,
        CancellationToken cancellationToken = default);
}
