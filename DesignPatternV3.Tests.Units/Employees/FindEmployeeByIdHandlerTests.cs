using DesignPatternV3.Business.Contracts.Exceptions.Employees;
using DesignPatternV3.Business.Employees.FindEmployeeById;
using DesignPatternV3.Entities.Employees;
using DesignPatternV3.Repository.Contracts;
using DesignPatternV3.Tests.Common.Builder;
using DesignPatternV3.Tests.Common.Builder.Command;
using Moq;

namespace DesignPatternV3.Tests.Units.Employees;

public class FindEmployeeByIdHandlerTests
{
	public readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new();

	[Fact]
	public async Task WhenEmployeeDoesNotExist_ShouldReturnEmployeeNotFoundException()
	{
		// Arrange
		var employee = EmployeeBuilder.AnEmployee.Build();
		var query = FindEmployeeByIdQueryBuilder.GetFromEmployee(employee);
		_employeeRepositoryMock.Setup(er => er.FindEmployeeById(employee.Id)).ReturnsAsync((Employee?)null);
		var handler = new FindEmployeeByIdHandler(_employeeRepositoryMock.Object);

		// Act
		Task handlerAction() => handler.Handle(query);

		// Assert
		await Assert.ThrowsAsync<EmployeeNotFoundException>(handlerAction);
	}

	[Fact]
	public async Task WhenEmployeeExist_ShouldReturnEmployeeDto()
	{
		// Arrange
		var employee = EmployeeBuilder.AnEmployee.Build();
		var query = FindEmployeeByIdQueryBuilder.GetFromEmployee(employee);
		var exceptedEmployeDto = employee.ToEmployeeDto();
		_employeeRepositoryMock.Setup(er => er.FindEmployeeById(employee.Id)).ReturnsAsync(employee);
		var handler = new FindEmployeeByIdHandler(_employeeRepositoryMock.Object);

		// Act
		var result = await handler.Handle(query);

		// Assert
		Assert.Equal(exceptedEmployeDto, result);
	}
}
