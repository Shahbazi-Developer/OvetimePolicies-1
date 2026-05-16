using OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;

namespace OvetimePolicies1.Core.Domain.EmployeeSalaries.Parameterts.Create;

public sealed record EmployeeSalaryCreateParameter(
    string lastName,
    string firstName,
    decimal baseSalary,
    DateTime date,
    decimal absorptionAllowance,
    decimal transportationAllowance,
    decimal tax,
    OvertimeCalculatorName overtimeCalculatorName,
    decimal overtimeAmount);
