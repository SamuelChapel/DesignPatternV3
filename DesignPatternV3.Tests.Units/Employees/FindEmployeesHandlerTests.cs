using DesignPatternV3.Business.Employees.FindEmployeeById;
using DesignPatternV3.Business.Employees.FindEmployees;
using DesignPatternV3.Entities.Employees;
using DesignPatternV3.Repository.Contracts;
using Moq;

namespace DesignPatternV3.Tests.Units.Employees;

public class FindEmployeesHandlerTests
{
	public readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new();

	[Theory]
	[InlineData(1)]
	[InlineData(5)]
	public async Task FindEmployees_ShouldReturnExpectedNumberOfEmployees(int expectedEmployeesCount)
	{
		// Arrange
		_employeeRepositoryMock
			.Setup(er => er.FindAllEmployees())
			.ReturnsAsync(Enumerable.Range(0, expectedEmployeesCount).Select(i => new Employee()));
		var handler = new FindEmployeesHandler(_employeeRepositoryMock.Object);
		var query = new FindEmployeesQuery();

		// Act
		var employees = (await handler.Handle(query)).ToList();

		// Assert
		Assert.Equal(expectedEmployeesCount, employees.Count);
		Assert.All(employees, e => Assert.True(typeof(EmployeeDto).IsEquivalentTo(e.GetType())));
	}
}