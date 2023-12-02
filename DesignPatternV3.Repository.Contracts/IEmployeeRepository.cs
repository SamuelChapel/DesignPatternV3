using DesignPatternV3.Entities.Employees;

namespace DesignPatternV3.Repository.Contracts;

public interface IEmployeeRepository
{
	public Employee? GetEmployeeById(int id);

	public IEnumerable<Employee> GetAllEmployees();

	public Employee AddEmployee(string firstName, string lastName, decimal salary);
}