using OvetimePolicies1.Core.Domain.EmployeeSalaries.Parameterts.Create;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.Parameterts.Update;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;
using Zamin.Core.Domain.Entities;

namespace OvetimePolicies1.Core.Domain.EmployeeSalaries.Entities;

public class EmployeeSalary : AggregateRoot<int>
{
    public string? LastName { get; private set; }
    public string? FirstName { get; private set; }
    public decimal BaseSalary { get; private set; }
    public DateTime Date { get; private set; }
    public decimal AbsorptionAllowance { get; private set; }
    public decimal TransportationAllowance { get; private set; }
    public decimal Tax { get; private set; }
    public OvertimeCalculatorName OvertimeCalculatorName { get; private set; } = null!;
    public decimal OvertimeAmount { get; private set; }
    public decimal ReceivedSalary { get; private set; }
    public Deleted Deleted { get; private set; } = new(false);

    private EmployeeSalary()
    {
    }

    public EmployeeSalary(EmployeeSalaryCreateParameter parameter)
    {
        LastName = parameter.lastName;
        FirstName = parameter.firstName;
        BaseSalary = parameter.baseSalary;
        Date = parameter.date;
        AbsorptionAllowance = parameter.absorptionAllowance;
        TransportationAllowance = parameter.transportationAllowance;
        Tax = parameter.tax;
        OvertimeCalculatorName = parameter.overtimeCalculatorName;
        ApplySalaryCalculation(parameter.overtimeAmount);
    }

    public void Update(EmployeeSalaryUpdateParameter parameter)
    {
        LastName = parameter.lastName;
        FirstName = parameter.firstName;
        BaseSalary = parameter.baseSalary;
        Date = parameter.date;
        AbsorptionAllowance = parameter.absorptionAllowance;
        TransportationAllowance = parameter.transportationAllowance;
        Tax = parameter.tax;
        OvertimeCalculatorName = parameter.overtimeCalculatorName;
        ApplySalaryCalculation(parameter.overtimeAmount);
    }

    public void Delete()
    {
        Deleted = new(true);
    }

    private void ApplySalaryCalculation(decimal overtimeAmount)
    {
        OvertimeAmount = overtimeAmount;
        ReceivedSalary = BaseSalary
                         + AbsorptionAllowance
                         + TransportationAllowance
                         + OvertimeAmount
                         - Tax;
    }
}
