using DesignPatternV3.Business.Contracts.Common;
using DesignPatternV3.Business.Contracts.Exceptions;
using DesignPatternV3.Business.Contracts.Exceptions.Employees;
using DesignPatternV3.Business.Employees.CreateEmployee;
using DesignPatternV3.Business.Employees.FindEmployeeById;
using DesignPatternV3.Business.Employees.FindEmployees;
using DesignPatternV3.Business.Employees.UpdateEmployee;

namespace DesignPatternV3.Controllers;

public class EmployeController(
	IQueryHandler<FindEmployeeByIdQuery, EmployeeDto> findEmployeeByIdHandler,
	IQueryHandler<FindEmployeesQuery, IEnumerable<EmployeeDto>> findEmployeesHandler,
	ICommandHandler<CreateEmployeeCommand, CreatedEmployeeDto> createEmployeeHandler,
	ICommandHandler<UpdateEmployeeCommand> updateEmployeeHandler)
{
	private readonly IQueryHandler<FindEmployeeByIdQuery, EmployeeDto> _findEmployeeByIdHandler = findEmployeeByIdHandler;
	private readonly IQueryHandler<FindEmployeesQuery, IEnumerable<EmployeeDto>> _findEmployeesHandler = findEmployeesHandler;
	private readonly ICommandHandler<CreateEmployeeCommand, CreatedEmployeeDto> _createEmployeeHandler = createEmployeeHandler;
	private readonly ICommandHandler<UpdateEmployeeCommand> _updateEmployeeHandler = updateEmployeeHandler;

	public async Task<string> AddEmployee(string firstName, string lastName, decimal salary)
	{
		try
		{
			var command = new CreateEmployeeCommand(firstName, lastName, salary);
			var createdEmployeeDto = await _createEmployeeHandler.Handle(command);

			return $"l'employé à été créé avec l'id {createdEmployeeDto.Id}";
		}
		catch (InvalidSalaryException ex)
		{
			return ex.Message;
		}
	}

	public async Task<string> UpdateEmployee(int id, string firstName, string lastName, decimal salary)
	{
		try
		{
			var command = new UpdateEmployeeCommand(id, firstName, lastName, salary);
			await _updateEmployeeHandler.Handle(command);

			return $"L'employé {id} à bien été mis à jour";
		}
		catch (EmployeeNotFoundException ex)
		{
			return ex.Message;
		}
	}

	public async Task<string> GetEmployee(int id)
	{
		try
		{
			var query = new FindEmployeeByIdQuery(id);
			var employeeDto = await _findEmployeeByIdHandler.Handle(query);

			return employeeDto.ToString();
		}
		catch (EmployeeNotFoundException ex)
		{
			return ex.Message;
		}
	}

	public async Task<string> GetAllEmployees()
	{
		var query = new FindEmployeesQuery();
		var employees = await _findEmployeesHandler.Handle(query);

		return string.Join("\n", employees);
	}
}
