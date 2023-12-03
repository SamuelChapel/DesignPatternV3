using DesignPatternV3.Business.Employees.FindEmployeeById;
using DesignPatternV3.Entities.Employees;

namespace DesignPatternV3.Tests.Common.Builder.Command;

public class FindEmployeeByIdQueryBuilder
{
	public static FindEmployeeByIdQuery GetFromEmployee(Employee employee)
		=> new(employee.Id);
}
