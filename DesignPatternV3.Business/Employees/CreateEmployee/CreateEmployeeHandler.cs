using DesignPatternV3.Business.Contracts.Common;
using DesignPatternV3.Business.Contracts.Exceptions;
using DesignPatternV3.Repository.Contracts;

namespace DesignPatternV3.Business.Employees.CreateEmployee;

public class CreateEmployeeHandler(IEmployeeRepository employeeRepository)
	: ICommandHandler<CreateEmployeeCommand, CreatedEmployeeDto>
{
	private readonly IEmployeeRepository _employeeRepository = employeeRepository;

	public async Task<CreatedEmployeeDto> Handle(CreateEmployeeCommand command)
	{
		if (command.Salary <= 0)
			throw new InvalidSalaryException();

		int id = await _employeeRepository.CreateEmployee(
			command.FirstName,
			command.LastName.ToUpper(),
			command.Salary);
		return new CreatedEmployeeDto(id);
	}
}
