using Microsoft.AspNetCore.Mvc;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Create;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Delete;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Update;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.Get;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;
using OvetimePolicies1.Endpoints.API.DTOs;
using Zamin.EndPoints.Web.Controllers;

namespace OvetimePolicies1.Endpoints.API.EmployeeSalaries
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalaryController : BaseController
    {

        #region Command

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmployeeSalary([FromBody] EmployeeSalaryCreateDto? dto)
        {
            if (dto is null)
                return BadRequest("Request body is required.");

            EmployeeSalaryCreateCommand command = new EmployeeSalaryCreateCommand()
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                BasicSalary = dto.BasicSalary,
                Date = dto.Date,
                Allowance = dto.Allowance,
                Transportation = dto.Transportation,
                Tax = dto.Tax,
                OvertimeCalculatorName = dto.OvertimeCalculatorName,
            };
            return await Create<EmployeeSalaryCreateCommand, int>(command);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmployeeSalary([FromBody] EmployeeSalaryDeleteDto? dto)
        {
            if (dto is null)
                return BadRequest("Request body is required.");

            EmployeeSalaryDeleteCommand command = new EmployeeSalaryDeleteCommand()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Date = dto.Date,
            };
            return await Delete(command);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateEmployeeSalary([FromBody] EmployeeSalaryUpdateDto? dto)
        {
            if (dto is null)
                return BadRequest("Request body is required.");

            EmployeeSalaryUpdateCommand command = new EmployeeSalaryUpdateCommand()
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                BasicSalary = dto.BasicSalary,
                Date = dto.Date,
                Allowance = dto.Allowance,
                Transportation = dto.Transportation,
                Tax = dto.Tax,
                OvertimeCalculatorName = dto.OvertimeCalculatorName,

            };
            return await Edit(command);
        }

        #endregion


        #region Query

        [HttpGet("Get")]
        public async Task<IActionResult> GetEmployeeSalary([FromQuery] EmployeeSalaryGetDto dto)
        {
            EmployeeSalaryGetQuery query = new EmployeeSalaryGetQuery()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Date = dto.Date,
            };

            return await Query<EmployeeSalaryGetQuery, EmployeeSalaryGetQr>(query);
        }

        [HttpGet("GetRange")]
        public async Task<IActionResult> GetEmployeeSalaryRange([FromQuery] EmployeeSalaryGetRangeDto dto)
        {
            EmployeeSalaryGetRangeQuery query = new EmployeeSalaryGetRangeQuery()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                FromDate = dto.FromDate,
                ToDate = dto.ToDate,
            };

            return await Query<EmployeeSalaryGetRangeQuery, List<EmployeeSalaryGetRangeQr>>(query);
        }

        #endregion


    }
}
