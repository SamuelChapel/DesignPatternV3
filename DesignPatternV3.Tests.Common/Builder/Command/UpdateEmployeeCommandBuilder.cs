using DesignPatternV3.Business.Employees.UpdateEmployee;
using DesignPatternV3.Entities.Employees;

namespace DesignPatternV3.Tests.Common.Builder.Command;

public class UpdateEmployeeCommandBuilder
{
	public static UpdateEmployeeCommand GetFromEmployee(Employee employee)
		=> new(employee.Id, employee.FirstName, employee.LastName, employee.Salary);
}
