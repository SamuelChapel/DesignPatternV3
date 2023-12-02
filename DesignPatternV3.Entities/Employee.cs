namespace DesignPatternV3.Entities;

public class Employee
{
	private decimal _salary;

	public int Id { get; set; }

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public decimal Salary
	{
		get => _salary;
		set
		{
			if (value <= 0)
				throw new InvalidSalaryException();

			_salary = value;
		}
	}

	public override string ToString()
	{
		return $"{Id,4} | {FirstName,-15}| {LastName,-15}| {Salary,5}";
	}

	public static Employee CreateEmployee(int id, string firstName, string lastName, decimal salary)
	{
		return new Employee()
		{
			Id = id,
			LastName = lastName,
			FirstName = firstName,
			Salary = salary
		};
	}
}
