using DesignPatternV3.Business.Contracts;
using DesignPatternV3.Business.Contracts.Exceptions;

namespace DesignPatternV3.Controllers;

public class EmployeController(IEmployeeService employeeService)
{
	private readonly IEmployeeService _employeeService = employeeService;

	public string AddEmployee(string firstName, string lastName, decimal salary)
	{
		try
		{
			var employee = _employeeService.AddEmployee(firstName, lastName, salary);

			return employee.ToString();
		}
		catch (InvalidSalaryException ex)
		{
			return ex.Message;
		}
	}

	public string GetEmployee(int id)
		=> _employeeService.GetEmployeeById(id)?.ToString() ?? $"L'employé avec l'id {id} n'existe pas";

	public string GetAllEmployees()
		=> string.Join("\n", _employeeService.GetAllEmployees());
}
