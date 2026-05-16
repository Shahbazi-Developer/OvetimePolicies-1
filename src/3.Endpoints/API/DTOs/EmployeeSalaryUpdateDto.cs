namespace OvetimePolicies1.Endpoints.API.DTOs
{
    public class EmployeeSalaryUpdateDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public decimal BaseSalary { get; set; }
        public DateTime Date { get; set; }
        public decimal AbsorptionAllowance { get; set; }
        public decimal TransportationAllowance { get; set; }
        public decimal Tax { get; set; }
        public string OvertimeCalculatorName { get; set; }
    }
}
