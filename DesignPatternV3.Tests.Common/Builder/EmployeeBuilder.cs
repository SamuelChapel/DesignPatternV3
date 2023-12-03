using DesignPatternV3.Entities.Employees;

namespace DesignPatternV3.Tests.Common.Builder;

public class EmployeeBuilder
{
	private int _id = 1;
	private string _firstName = "fooFirstName";
	private string _lastName = "fooLastName";
	private decimal _salary = 1000;

	public static EmployeeBuilder AnEmployee => new();

	public EmployeeBuilder WithId(int id)
	{
		_id = id;
		return this;
	}

	public EmployeeBuilder WithFirstName(string firstName)
	{
		_firstName = firstName;
		return this;
	}

	public EmployeeBuilder WithLastName(string lastName)
	{
		_lastName = lastName;
		return this;
	}

	public EmployeeBuilder WithSalary(decimal salary)
	{
		_salary = salary;
		return this;
	}

	public Employee Build()
	{
		var employee = new Employee()
		{
			Id = _id,
			FirstName = _firstName,
			LastName = _lastName,
			Salary = _salary,
		};

		return employee;
	}

	public static Employee GetEmployee(int id)
		=> new()
		{
			Id = id,
			FirstName = $"Employee FirstName {id}",
			LastName = $"Employee LastName {id}",
			Salary = 1000 * id
		};

	public static IEnumerable<Employee> GetEmployees(int count)
		=> Enumerable.Range(0, count).Select(GetEmployee);
}
