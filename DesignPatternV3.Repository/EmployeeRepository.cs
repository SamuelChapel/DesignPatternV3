using Bogus;
using DesignPatternV3.Entities.Employees;
using DesignPatternV3.Repository.Contracts;

namespace DesignPatternV3.Repository;

public class EmployeeRepository : IEmployeeRepository
{
	private readonly Dictionary<int, Employee> _employees = [];

	// Create 100 random employees at the initialization for testing purpose
	public EmployeeRepository()
		=> _employees = CreateRandomEmployees(100)
		.Select(e => new KeyValuePair<int, Employee>(e.Id, e))
		.ToDictionary();

	public List<Employee> Employees => _employees.Values.ToList();

	public Task<IEnumerable<Employee>> FindAllEmployees()
		=> Task.FromResult(_employees.Values.AsEnumerable());

	public Task<Employee?> FindEmployeeById(int id)
	{
		return Task.FromResult(_employees.FirstOrDefault(e => e.Key == id).Value ?? null);
	}

	public Task<int> CreateEmployee(string firstName, string lastName, decimal salary)
	{
		var employee = new Employee()
		{
			Id = GetMinId(),
			FirstName = firstName,
			LastName = lastName,
			Salary = salary
		};

		_employees.Add(employee.Id, employee);

		return Task.FromResult(employee.Id);
	}

	public Task UpdateEmployee(Employee employee)
		=> Task.FromResult(_employees[employee.Id] = employee);

	#region Random Employees Creation

	public Employee CreateRandomEmployee(int? id = null)
	{
		return new Faker<Employee>("fr")
			.RuleFor(e => e.Id, id ?? GetMinId())
			.RuleFor(e => e.FirstName, f => f.Name.FirstName())
			.RuleFor(e => e.LastName, f => f.Name.LastName())
			.RuleFor(e => e.Salary, Random.Shared.Next(1200, 10000)).Generate();
	}

	public IEnumerable<Employee> CreateRandomEmployees(int count)
	{
		var ids = Enumerable.Range(1, 9999).Except(_employees.Keys).Take(count);

		foreach (int id in ids)
		{
			yield return CreateRandomEmployee(id);
		}
	}

	private int GetMinId()
	{
		return Enumerable.Range(1, 9999).Except(_employees.Keys).Min();
	}
	#endregion
}
