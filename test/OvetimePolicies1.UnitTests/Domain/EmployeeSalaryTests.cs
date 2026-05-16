using OvetimePolicies1.Core.Domain.EmployeeSalaries.Entities;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.Parameterts.Create;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.Parameterts.Update;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;

namespace OvetimePolicies1.UnitTests.Domain;

public sealed class EmployeeSalaryTests
{
    private static EmployeeSalaryCreateParameter CreateParameter(
        decimal basic = 1000,
        decimal allowance = 100,
        decimal transportation = 50,
        decimal tax = 200,
        decimal overtimeAmount = 150,
        string calculator = "CalcurlatorA")
    {
        return new EmployeeSalaryCreateParameter(
            lastName: "Test",
            firstName: "User",
            basicSalary: basic,
            date: new DateTime(2025, 5, 1),
            allowance: allowance,
            transportation: transportation,
            tax: tax,
            overtimeCalculatorName: new OvertimeCalculatorName(calculator),
            overtimeAmount: overtimeAmount);
    }

    [Fact]
    public void Create_sets_fields_and_received_salary_formula()
    {
        var p = CreateParameter(
            basic: 5000,
            allowance: 500,
            transportation: 100,
            tax: 300,
            overtimeAmount: 200);

        var entity = new EmployeeSalary(p);

        Assert.Equal("Test", entity.LastName);
        Assert.Equal("User", entity.FirstName);
        Assert.Equal(5000, entity.BasicSalary);
        Assert.Equal(500, entity.Allowance);
        Assert.Equal(100, entity.Transportation);
        Assert.Equal(300, entity.Tax);
        Assert.Equal(200, entity.OvertimeAmount);
        Assert.False(entity.Deleted.Value);

        var expectedReceived = 5000 + 500 + 100 + 200 - 300;
        Assert.Equal(expectedReceived, entity.ReceivedSalary);
    }

    [Fact]
    public void Update_reapplies_salary_calculation()
    {
        var entity = new EmployeeSalary(CreateParameter());
        var update = new EmployeeSalaryUpdateParameter(
            lastName: "New",
            firstName: "Name",
            basicSalary: 2000,
            date: new DateTime(2025, 6, 15),
            allowance: 0,
            transportation: 0,
            tax: 100,
            overtimeCalculatorName: new OvertimeCalculatorName("CalcurlatorB"),
            overtimeAmount: 400);

        entity.Update(update);

        Assert.Equal("New", entity.LastName);
        Assert.Equal("Name", entity.FirstName);
        Assert.Equal(2000, entity.BasicSalary);
        Assert.Equal(400, entity.OvertimeAmount);
        Assert.Equal(2000 + 0 + 0 + 400 - 100, entity.ReceivedSalary);
    }

    [Fact]
    public void Delete_marks_deleted_flag()
    {
        var entity = new EmployeeSalary(CreateParameter());
        Assert.False(entity.Deleted.Value);
        entity.Delete();
        Assert.True(entity.Deleted.Value);
    }
}
