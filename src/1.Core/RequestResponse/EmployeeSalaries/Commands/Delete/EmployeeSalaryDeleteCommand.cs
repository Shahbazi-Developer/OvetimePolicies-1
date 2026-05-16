using Zamin.Core.RequestResponse.Commands;

namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Delete;

public class EmployeeSalaryDeleteCommand : ICommand
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime Date { get; set; }
}
