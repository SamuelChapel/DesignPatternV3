using Bogus;
using DesignPatternV3.Entities.Employees;
using DesignPatternV3.Repository.Contracts;

namespace DesignPatternV3.Repository;

public class EmployeeRepository : IEmployeeRepository
{
	private readonly List<Employee> _employees = [];

	public EmployeeRepository()
		=> _employees = CreateRandomEmployees(100).ToList();

	public List<Employee> Employees => _employees;

	public Employee AddEmployee(string firstName, string lastName, decimal salary)
	{
		var employee = CreateEmployee(
			Enumerable.Range(1, 9999).Except(_employees.Select(e => e.Id)).Min(),
			firstName,
			lastName,
			salary
			);

		_employees.Add(employee);

		return employee;
	}

	public IEnumerable<Employee> GetAllEmployees()
		=> _employees;

	public Employee? GetEmployeeById(int id)
		=> _employees.FirstOrDefault(e => e.Id == id);

	public Employee CreateEmployee(int id, string firstName, string lastName, decimal salary)
	{
		return new Employee()
		{
			Id = id,
			FirstName = firstName,
			LastName = lastName,
			Salary = salary
		};
	}

	public Employee CreateRandomEmployee(int? id = null)
	{
		return new Faker<Employee>("fr")
			.RuleFor(e => e.Id, id ?? Enumerable.Range(1, 9999).Except(_employees.Select(e => e.Id)).Min())
			.RuleFor(e => e.FirstName, f => f.Name.FirstName())
			.RuleFor(e => e.LastName, f => f.Name.LastName())
			.RuleFor(e => e.Salary, Random.Shared.Next(1200, 10000)).Generate();
	}

	public IEnumerable<Employee> CreateRandomEmployees(int count)
	{
		var ids = Enumerable.Range(1, 9999).Except(_employees.Select(e => e.Id)).Take(count);

		foreach (int id in ids)
		{
			yield return CreateRandomEmployee(id);
		}
	}
}
