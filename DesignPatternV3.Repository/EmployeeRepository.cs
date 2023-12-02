using DesignPatternV3.Entities;
using DesignPatternV3.Repository.Contracts;

namespace DesignPatternV3.Repository;

public class EmployeeRepository : IEmployeeRepository
{
	private readonly List<Employee> _employees = [];

	public List<Employee> Employees => _employees;

	public Employee AddEmployee(string firstName, string lastName, decimal salary)
	{
		var employee = Employee.CreateEmployee(_employees.Count, firstName, lastName, salary);

		_employees.Add(employee);

		return employee;
	}

	public Employee? GetEmployee(int id) => _employees.FirstOrDefault(e => e.Id == id);
}
