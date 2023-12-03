using DesignPatternV3.Business.Contracts.Common;

namespace DesignPatternV3.Business.Employees.FindEmployeeById;

public record EmployeeDto(
	int Id,
	string FirstName,
	string LastName,
	decimal Salary
	) : IQuery;