namespace DesignPatternV3.Entities.Employees;

public class Employee
{
	public int Id { get; set; }

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public decimal Salary { get; set; }

	public override string ToString()
	{
		return $"{Id,4} | {FirstName,-15}| {LastName,-15}| {Salary,5}";
	}
}
