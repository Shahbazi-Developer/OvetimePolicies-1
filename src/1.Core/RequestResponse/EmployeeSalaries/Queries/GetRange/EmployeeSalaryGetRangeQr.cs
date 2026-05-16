namespace OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;

public sealed class EmployeeSalaryGetRangeQr
{
    public int? Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public decimal BasicSalary { get; set; }
    public DateTime Date { get; set; }
    public decimal Allowance { get; set; }
    public decimal Transportation { get; set; }
    public decimal Tax { get; set; }
    public string? OvertimeCalculatorName { get; set; }
    public decimal OvertimeAmount { get; set; }
    public decimal ReceivedSalary { get; set; }
}
