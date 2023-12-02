using DesignPatternV3.Business.Contracts;

namespace DesignPatternV3.Controllers;

public class EmployeController(IEmployeeService employeeService)
{
	private readonly IEmployeeService _employeeService = employeeService;

	public string AddEmployee(string firstName, string lastName, decimal salary)
	{
		var employee = _employeeService.AddEmployee(firstName, lastName, salary);
		return employee;
	}

	public string GetEmployee(int id)
		=> _employeeService.GetEmployee(id)?.ToString() ?? $"L'employé avec l'id {id} n'existe pas";

	public string GetAllEmployees()
		=> string.Join("\n", _employeeService.GetAllEmployees());
}
