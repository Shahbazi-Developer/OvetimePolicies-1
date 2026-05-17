using Microsoft.Extensions.Logging;
using OvetimePolicies1.Core.Contracts.EmployeeSalaries.Command;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Commands.Delete;
using OvetimePolicies1.SharedKernel.Translators;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Extensions.Translations.Abstractions;
using Zamin.Utilities;

namespace OvetimePolicies1.Core.ApplicationService.EmployeeSalaries.Commands.Delete;

public class EmployeeSalaryDeleteCommandHandler : CommandHandler<EmployeeSalaryDeleteCommand>
{
    private readonly IEmployeeSalaryCommandRepasitory _employeeSalaryCommandRepasitory;
    private readonly ILogger<EmployeeSalaryDeleteCommandHandler> _logger;
    private readonly ITranslator _translator;

    public EmployeeSalaryDeleteCommandHandler(ZaminServices zaminServices,
                                              ILogger<EmployeeSalaryDeleteCommandHandler> logger,
                                              IEmployeeSalaryCommandRepasitory employeeSalaryCommandRepasitory,
                                              ITranslator translator) : base(zaminServices)
    {
        _logger = logger;
        _employeeSalaryCommandRepasitory = employeeSalaryCommandRepasitory;
        _translator = translator;
    }

    public override async Task<CommandResult> Handle(EmployeeSalaryDeleteCommand command)
    {
        var entity = await _employeeSalaryCommandRepasitory.GetByPersonAndMonthAsync(
            command.FirstName,
            command.LastName,
            command.Date);

        if (entity is null)
        {
            _logger.Log(LogLevel.Information,_translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, TranslatorKeys.EMPLOYEE_SALARY_RECORD]);

            throw new InvalidEntityStateException(_translator[TranslatorKeys.VALIDATION_ERROR_NOT_EXIST, TranslatorKeys.EMPLOYEE_SALARY_RECORD]);
        }

        entity.Delete();
        await _employeeSalaryCommandRepasitory.CommitAsync();

        return Ok();
    }
}
