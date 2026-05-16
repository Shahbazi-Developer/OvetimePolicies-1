using OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.OvertimePolicies;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.Parameterts.Create;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.Parameterts.Update;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Create;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Update;

namespace OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.Mappers;

public static class EmployeeSalaryMapper
{
    public static EmployeeSalaryCreateParameter ToParameter(this EmployeeSalaryCreateCommand command)
    {
        var overtimeAmount = OvertimePolicyResolver.GetOvertimeAmount(
            command.OvertimeCalculatorName,
            command.BasicSalary,
            command.Allowance);

        return new EmployeeSalaryCreateParameter(
            lastName: command.LastName,
            firstName: command.FirstName,
            basicSalary: command.BasicSalary,
            date: command.Date,
            allowance: command.Allowance,
            transportation: command.Transportation,
            tax: command.Tax,
            overtimeCalculatorName: command.OvertimeCalculatorName,
            overtimeAmount: overtimeAmount);
    }

    public static EmployeeSalaryUpdateParameter ToParameter(this EmployeeSalaryUpdateCommand command)
    {
        var overtimeAmount = OvertimePolicyResolver.GetOvertimeAmount(
            command.OvertimeCalculatorName,
            command.BasicSalary,
            command.Allowance);

        return new EmployeeSalaryUpdateParameter(
            lastName: command.LastName,
            firstName: command.FirstName,
            basicSalary: command.BasicSalary,
            date: command.Date,
            allowance: command.Allowance,
            transportation: command.Transportation,
            tax: command.Tax,
            overtimeCalculatorName: command.OvertimeCalculatorName,
            overtimeAmount: overtimeAmount);
    }
}
