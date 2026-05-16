using Microsoft.Extensions.Logging;
using OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.Mappers;
using OvetimePolicies1.Core.Contracts.EmployeeSalaries.Command;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.Entities;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Create;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.Commands.Create;

public class EmployeeSalaryCreateCommandHandler : CommandHandler<EmployeeSalaryCreateCommand, int>
{
    private readonly IEmployeeSalaryCommandRepasitory _employeeSalaryCommandRepasitory;

    public EmployeeSalaryCreateCommandHandler(
        ZaminServices zaminServices,
        IEmployeeSalaryCommandRepasitory employeeSalaryCommandRepasitory,
        ILogger<EmployeeSalaryCreateCommandHandler> logger,
        ITranslator translator) : base(zaminServices)
    {
        _employeeSalaryCommandRepasitory = employeeSalaryCommandRepasitory;
    }

    public override async Task<CommandResult<int>> Handle(EmployeeSalaryCreateCommand command)
    {
        var entity = new EmployeeSalary(command.ToParameter());

        await _employeeSalaryCommandRepasitory.InsertAsync(entity);
        await _employeeSalaryCommandRepasitory.CommitAsync();

        return Ok(entity.Id);
    }
}
