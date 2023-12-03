using DesignPatternV3.Business.Contracts.Common;
using DesignPatternV3.Business.Contracts.Exceptions.Employees;
using DesignPatternV3.Repository.Contracts;

namespace DesignPatternV3.Business.Employees.UpdateEmployee;

public class UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
	: ICommandHandler<UpdateEmployeeCommand>
{
	private readonly IEmployeeRepository _employeeRepository = employeeRepository;

	public async Task Handle(UpdateEmployeeCommand command)
	{
		var employee = await _employeeRepository.FindEmployeeById(command.Id)
			?? throw new EmployeeNotFoundException(command.Id);

		employee.FirstName = command.FirstName;
		employee.LastName = command.LastName;
		employee.Salary = command.Salary;

		await _employeeRepository.UpdateEmployee(employee);
	}
}
