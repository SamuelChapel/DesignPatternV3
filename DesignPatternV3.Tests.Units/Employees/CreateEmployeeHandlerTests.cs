using DesignPatternV3.Business.Employees.CreateEmployee;
using DesignPatternV3.Repository.Contracts;
using DesignPatternV3.Tests.Common.Builder;
using DesignPatternV3.Tests.Common.Builder.Command;
using Moq;

namespace DesignPatternV3.Tests.Units.Employees;

public class CreateEmployeeHandlerTests
{
	public readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new();

	[Theory]
	[InlineData(0)]
	[InlineData(2)]
	public async Task ShouldReturnEmployeeIdCreated(int id)
	{
		// Arrange
		var employee = EmployeeBuilder.AnEmployee.WithId(id).Build();
		var command = CreateEmployeeCommandBuilder.GetFromEmployee(employee);
		_employeeRepositoryMock
			.Setup(er => er.CreateEmployee(employee.FirstName, employee.LastName, employee.Salary))
			.ReturnsAsync(id);
		var handler = new CreateEmployeeHandler(_employeeRepositoryMock.Object);

		// Act
		var createdEmployeeDto = await handler.Handle(command);

		// Assert
		Assert.Equal(employee.Id, createdEmployeeDto.Id);
	}
}
