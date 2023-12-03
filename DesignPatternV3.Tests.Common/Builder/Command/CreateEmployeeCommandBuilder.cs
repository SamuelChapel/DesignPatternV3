using DesignPatternV3.Business.Employees.CreateEmployee;
using DesignPatternV3.Entities.Employees;

namespace DesignPatternV3.Tests.Common.Builder.Command;

public class CreateEmployeeCommandBuilder
{
	public static CreateEmployeeCommand GetFromEmployee(Employee employee)
		=> new(employee.FirstName, employee.LastName, employee.Salary);
}
