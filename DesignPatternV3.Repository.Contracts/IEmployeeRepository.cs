using DesignPatternV3.Entities.Employees;

namespace DesignPatternV3.Repository.Contracts;

public interface IEmployeeRepository
{
	public Task<Employee?> FindEmployeeById(int id);

	public Task<IEnumerable<Employee>> FindAllEmployees();

	public Task<int> CreateEmployee(string firstName, string lastName, decimal salary);

	public Task UpdateEmployee(Employee employee);
}