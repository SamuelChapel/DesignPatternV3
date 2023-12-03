using DesignPatternV3.Business.Contracts.Common;
using DesignPatternV3.Business.Contracts.Exceptions.Employees;
using DesignPatternV3.Repository.Contracts;

namespace DesignPatternV3.Business.Employees.FindEmployeeById;

public class FindEmployeeByIdHandler(IEmployeeRepository employeeRepository)
	: IQueryHandler<FindEmployeeByIdQuery, EmployeeDto>
{
	private readonly IEmployeeRepository _employeeRepository = employeeRepository;

	public async Task<EmployeeDto> Handle(FindEmployeeByIdQuery query)
	{
		var employee = await _employeeRepository.FindEmployeeById(query.Id);

		return employee is null ?
			throw new EmployeeNotFoundException(query.Id) :
			new EmployeeDto(employee.Id, employee.FirstName, employee.LastName, employee.Salary);
	}
}
