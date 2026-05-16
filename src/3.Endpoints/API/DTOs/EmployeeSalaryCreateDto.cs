namespace OvetimePolicies1.Endpoints.API.DTOs
{
    public class EmployeeSalaryCreateDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime Date { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public decimal Tax { get; set; }
        public string OvertimeCalculatorName { get; set; }
    }
}
