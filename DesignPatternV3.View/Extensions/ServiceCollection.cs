using DesignPatternV3.Business;
using DesignPatternV3.Business.Contracts;
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
		container.RegisterType<IEmployeeService, EmployeeService>();
		container.RegisterType<IEmployeeRepository, EmployeeRepository>();
		container.RegisterSingleton<ILocalStorage, LocalStorage>();

		return container;
	}
}
