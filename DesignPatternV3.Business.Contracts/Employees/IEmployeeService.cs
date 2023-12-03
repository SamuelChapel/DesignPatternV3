using DesignPatternV3.Entities.Employees;

namespace DesignPatternV3.Business.Contracts.Employees;

public interface IEmployeeService
{
	/// <summary>
	/// Method to get an employee by id
	/// </summary>
	/// <param name="id">Employee id</param>
	/// <returns>Return the <see cref="Employee"/> if id is valid else <c>Null</c></returns>
	public Employee? GetEmployeeById(int id);

	/// <summary>
	/// Method to get all the employees
	/// </summary>
	/// <returns>All the employees</returns>
	public IEnumerable<Employee> GetAllEmployees();

	/// <summary>
	/// Method to add a new employee
	/// </summary>
	/// <param name="firstName">Employee firstname</param>
	/// <param name="lastName">Employee lastname</param>
	/// <param name="salary">Employee salary</param>
	/// <returns>The employee created</returns>
	public Employee AddEmployee(string firstName, string lastName, decimal salary);
}