using DesignPatternV3.Business.Employees.FindEmployeeById;
using DesignPatternV3.Entities.Employees;

namespace DesignPatternV3.Tests.Common.Builder;

public static class EmployeeExtension
{
	public static EmployeeDto ToEmployeeDto(this Employee employee)
		=> new(employee.Id, employee.FirstName, employee.LastName, employee.Salary);
}
