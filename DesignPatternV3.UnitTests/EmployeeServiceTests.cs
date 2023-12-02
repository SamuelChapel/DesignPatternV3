using DesignPatternV3.Business;
using DesignPatternV3.Repository.Contracts;
using DesignPatternV3.Entities.Employees;
using Moq;

namespace DesignPatternV3.UnitTests;

public class EmployeeServiceTests
{
	public readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new();

	[Theory]
	[InlineData(1)]
	[InlineData(5)]
	public void GetAllEmployees_ShouldReturnExpectedNumberOfEmployees(int expectedEmployeesCount)
	{
		// Arrange
		_employeeRepositoryMock
			.Setup(er => er.GetAllEmployees())
			.Returns(Enumerable.Range(0, expectedEmployeesCount).Select(i => new Employee()));
		var employeeService = new EmployeeService(_employeeRepositoryMock.Object);

		// Act
		var employees = employeeService.GetAllEmployees().ToList();

		// Assert
		Assert.Equal(expectedEmployeesCount, employees.Count);
		Assert.All(employees, e => Assert.True(typeof(Employee).IsEquivalentTo(e.GetType())));
	}
}