using DesignPatternV3.Business.Contracts.Exceptions.Employees;
using DesignPatternV3.Business.Employees.UpdateEmployee;
using DesignPatternV3.Entities.Employees;
using DesignPatternV3.Repository.Contracts;
using DesignPatternV3.Tests.Common.Builder;
using DesignPatternV3.Tests.Common.Builder.Command;
using Moq;

namespace DesignPatternV3.Tests.Units.Employees;

public class UpdateEmployeeHandlerTests
{
	public readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new();

	[Fact]
	public async Task WhenEmployeeDoesNotExist_ShouldThrowEmployeeNotFoundException()
	{
		// Arrange
		var employee = EmployeeBuilder.AnEmployee.Build();
		var command = UpdateEmployeeCommandBuilder.GetFromEmployee(employee);
		_employeeRepositoryMock.Setup(er => er.FindEmployeeById(employee.Id)).ReturnsAsync((Employee?)null);
		var handler = new UpdateEmployeeHandler(_employeeRepositoryMock.Object);

		// Act
		Task handlerAction() => handler.Handle(command);

		// Assert
		await Assert.ThrowsAsync<EmployeeNotFoundException>(handlerAction);
	}

	[Fact]
	public async Task WhenEmployeeExist_ShouldNotThrowException()
	{
		// Arrange
		var employee = EmployeeBuilder.AnEmployee.Build();
		var command = UpdateEmployeeCommandBuilder.GetFromEmployee(employee);
		_employeeRepositoryMock.Setup(er => er.FindEmployeeById(employee.Id)).ReturnsAsync(employee);
		var handler = new UpdateEmployeeHandler(_employeeRepositoryMock.Object);

		// Act
		var exception = await Record.ExceptionAsync(() =>  handler.Handle(command));

		// Assert
		Assert.Null(exception);
	}
}
