using Microsoft.Extensions.Logging;
using OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.Mappers;
using OvetimePolicies1.Core.Contracts.EmployeeSalaries.Command;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Update;
using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.Commands.Update;

public class EmployeeSalaryUpdateCommandHandler : CommandHandler<EmployeeSalaryUpdateCommand>
{
    private readonly IEmployeeSalaryCommandRepasitory _employeeSalaryCommandRepasitory;
    private readonly ILogger<EmployeeSalaryUpdateCommandHandler> _logger;
    private readonly ITranslator _translator;

    public EmployeeSalaryUpdateCommandHandler(
        ZaminServices zaminServices,
        ITranslator translator,
        ILogger<EmployeeSalaryUpdateCommandHandler> logger,
        IEmployeeSalaryCommandRepasitory employeeSalaryCommandRepasitory) : base(zaminServices)
    {
        _translator = translator;
        _logger = logger;
        _employeeSalaryCommandRepasitory = employeeSalaryCommandRepasitory;
    }

    public override async Task<CommandResult> Handle(EmployeeSalaryUpdateCommand command)
    {
        var entity = await _employeeSalaryCommandRepasitory.GetByPersonAndMonthAsync(
            command.FirstName,
            command.LastName,
            command.Date);

        if (entity is null)
        {
            _logger.Log(
                LogLevel.Information,
                _translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, TranslatorKeys.EMPLOYEE_SALARY_RECORD]);

            throw new InvalidEntityStateException(
                _translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, TranslatorKeys.EMPLOYEE_SALARY_RECORD]);
        }

        entity.Update(command.ToParameter());
        await _employeeSalaryCommandRepasitory.CommitAsync();

        return Ok();
    }
}
