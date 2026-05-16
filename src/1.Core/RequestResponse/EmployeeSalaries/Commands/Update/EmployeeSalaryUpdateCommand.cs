using Zamin.Core.RequestResponse.Commands;

namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Update;

public class EmployeeSalaryUpdateCommand : ICommand
{
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public decimal BaseSalary { get; set; }
    public DateTime Date { get; set; }
    public decimal AbsorptionAllowance { get; set; }
    public decimal TransportationAllowance { get; set; }
    public decimal Tax { get; set; }
    public required string OvertimeCalculatorName { get; set; }
}
