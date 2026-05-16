using Zamin.Core.RequestResponse.Commands;

namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Update;

public class EmployeeSalaryUpdateCommand : ICommand
{
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public decimal BasicSalary { get; set; }
    public DateTime Date { get; set; }
    public decimal Allowance { get; set; }
    public decimal Transportation { get; set; }
    public decimal Tax { get; set; }
    public required string OvertimeCalculatorName { get; set; }
}
