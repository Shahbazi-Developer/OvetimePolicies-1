using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.Get;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;

namespace OvetimePolicies1.Infra.Data.Sql.Queries.EmployeeSalaries.Entities;

public class EmployeeSalary
{
    public int Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public decimal BaseSalary { get; set; }
    public DateTime Date { get; set; }
    public decimal AbsorptionAllowance { get; set; }
    public decimal TransportationAllowance { get; set; }
    public decimal Tax { get; set; }
    public string? OvertimeCalculatorName { get; set; }
    public decimal OvertimeAmount { get; set; }
    public decimal ReceivedSalary { get; set; }
    public bool Deleted { get; set; }

    public static explicit operator EmployeeSalaryGetQr(EmployeeSalary entity) => new()
    {
        Id = entity.Id,
        LastName = entity.LastName,
        FirstName = entity.FirstName,
        BaseSalary = entity.BaseSalary,
        Date = entity.Date,
        AbsorptionAllowance = entity.AbsorptionAllowance,
        TransportationAllowance = entity.TransportationAllowance,
        Tax = entity.Tax,
        OvertimeCalculatorName = entity.OvertimeCalculatorName,
        OvertimeAmount = entity.OvertimeAmount,
        ReceivedSalary = entity.ReceivedSalary
    };

    public static explicit operator EmployeeSalaryGetRangeQr(EmployeeSalary entity) => new()
    {
        Id = entity.Id,
        LastName = entity.LastName,
        FirstName = entity.FirstName,
        BaseSalary = entity.BaseSalary,
        Date = entity.Date,
        AbsorptionAllowance = entity.AbsorptionAllowance,
        TransportationAllowance = entity.TransportationAllowance,
        Tax = entity.Tax,
        OvertimeCalculatorName = entity.OvertimeCalculatorName,
        OvertimeAmount = entity.OvertimeAmount,
        ReceivedSalary = entity.ReceivedSalary
    };
}
