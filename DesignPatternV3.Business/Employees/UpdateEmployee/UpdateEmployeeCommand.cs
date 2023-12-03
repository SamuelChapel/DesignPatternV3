using DesignPatternV3.Business.Contracts.Common;

namespace DesignPatternV3.Business.Employees.UpdateEmployee;

public record UpdateEmployeeCommand(
	int Id,
	string FirstName,
	string LastName,
	decimal Salary
	) : ICommand;
