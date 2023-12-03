using DesignPatternV3.Business.Contracts.Common;
using DesignPatternV3.Business.Employees.FindEmployeeById;
using DesignPatternV3.Repository.Contracts;

namespace DesignPatternV3.Business.Employees.FindEmployees;

public class FindEmployeesHandler(IEmployeeRepository employeeRepository)
	: IQueryHandler<FindEmployeesQuery, IEnumerable<EmployeeDto>>
{
	private const int DEFAULTPAGE = 1;
	private const int DEFAULTCOUNT = 50;

	private readonly IEmployeeRepository _employeeRepository = employeeRepository;

	public async Task<IEnumerable<EmployeeDto>> Handle(FindEmployeesQuery query)
	{
		var employees = await _employeeRepository.FindAllEmployees();

		var page = ParsePage(query.Page);
		var count = ParseMaxResult(query.Count);
		var startIndex = (page - 1) * count;

		return employees
			.Skip(startIndex)
			.Take(count)
			.Select(e => new EmployeeDto(e.Id, e.FirstName, e.LastName, e.Salary));
	}

	private int ParsePage(int? pageQuery)
		=> ParseIntegerOrDefaultValue(pageQuery, DEFAULTPAGE);

	private int ParseMaxResult(int? maxResultQuery)
		=> ParseIntegerOrDefaultValue(maxResultQuery, DEFAULTCOUNT);

	private int ParseIntegerOrDefaultValue(int? integerToParse, int defaultValue)
		=> integerToParse ?? defaultValue;
}
