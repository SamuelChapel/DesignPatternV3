using DesignPatternV3.Business.Contracts.Common;

namespace DesignPatternV3.Business.Employees.FindEmployeeById;

public record FindEmployeeByIdQuery(int Id) : IQuery;
