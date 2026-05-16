using OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;

namespace OvetimePolicies1.Core.Domain.EmployeeSalaries.Parameterts.Update;

public sealed record EmployeeSalaryUpdateParameter(
    string lastName,
    string firstName,
    decimal basicSalary,
    DateTime date,
    decimal allowance,
    decimal transportation,
    decimal tax,
    OvertimeCalculatorName overtimeCalculatorName,
    decimal overtimeAmount);
