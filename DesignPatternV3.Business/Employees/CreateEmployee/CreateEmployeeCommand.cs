using DesignPatternV3.Business.Contracts.Common;

namespace DesignPatternV3.Business.Employees.CreateEmployee;

public record CreateEmployeeCommand(
	string FirstName,
	string LastName,
	decimal Salary
	) : ICommand;
