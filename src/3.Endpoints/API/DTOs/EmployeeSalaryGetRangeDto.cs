namespace OvetimePolicies1.Endpoints.API.DTOs
{
    public class EmployeeSalaryGetRangeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
