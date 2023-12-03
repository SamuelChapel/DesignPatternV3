using DesignPatternV3.Business.Contracts.Common;
using DesignPatternV3.Business.Employees.CreateEmployee;
using DesignPatternV3.Business.Employees.FindEmployeeById;
using DesignPatternV3.Business.Employees.FindEmployees;
using DesignPatternV3.Business.Employees.UpdateEmployee;
using DesignPatternV3.Controllers;
using DesignPatternV3.Repository;
using DesignPatternV3.Repository.Contracts;
using Unity;

namespace DesignPatternV3.View.Extensions;

public static class ServiceCollection
{
	public static IUnityContainer AddServices(this IUnityContainer container)
	{
		container.RegisterType<EmployeController>();

		container.RegisterType<ICommandHandler<CreateEmployeeCommand, CreatedEmployeeDto>, CreateEmployeeHandler>();
		container.RegisterType<IQueryHandler<FindEmployeeByIdQuery, EmployeeDto>, FindEmployeeByIdHandler>();
		container.RegisterType<IQueryHandler<FindEmployeesQuery, IEnumerable<EmployeeDto>>, FindEmployeesHandler>();
		container.RegisterType<ICommandHandler<UpdateEmployeeCommand>, UpdateEmployeeHandler>();

		container.RegisterType<IEmployeeRepository, EmployeeRepository>();
		container.RegisterSingleton<ILocalStorage, LocalStorage>();

		return container;
	}
}
