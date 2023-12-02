using DesignPatternV3.Business.Contracts;
using DesignPatternV3.Business.Contracts.Exceptions;
using DesignPatternV3.Entities.Employees;
using DesignPatternV3.Repository.Contracts;

namespace DesignPatternV3.Business;

public class EmployeeService : IEmployeeService
{
	private readonly IEmployeeRepository _employeeRepository;

	public EmployeeService(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

	public Employee AddEmployee(string firstName, string lastName, decimal salary)
	{
		if (salary <= 0)
			throw new InvalidSalaryException();

		return _employeeRepository.AddEmployee(firstName, lastName, salary);
	}

	public IEnumerable<Employee> GetAllEmployees()
	{
		return _employeeRepository.GetAllEmployees();
	}

	public Employee? GetEmployeeById(int id)
	{
		return _employeeRepository.GetEmployeeById(id);
	}
}
