using DesignPatternV3.Business.Contracts.Common;

namespace DesignPatternV3.Business.Employees.FindEmployees;

public record FindEmployeesQuery(
	int? Page = null,
	int? Count = null
	) : IQuery;
