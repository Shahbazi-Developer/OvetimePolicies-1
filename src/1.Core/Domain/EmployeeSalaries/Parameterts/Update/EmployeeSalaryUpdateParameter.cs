using OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;

namespace OvetimePolicies1.Core.Domain.EmployeeSalaries.Parameterts.Update;

public sealed record EmployeeSalaryUpdateParameter(
    string lastName,
    string firstName,
    decimal baseSalary,
    DateTime date,
    decimal absorptionAllowance,
    decimal transportationAllowance,
    decimal tax,
    OvertimeCalculatorName overtimeCalculatorName,
    decimal overtimeAmount);
