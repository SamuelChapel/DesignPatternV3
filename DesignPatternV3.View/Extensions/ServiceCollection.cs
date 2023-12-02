using DesignPatternV3.Repository.Contracts;
using DesignPatternV3.Repository;
using Unity;
using DesignPatternV3.Controllers;

namespace DesignPatternV3.View.Extensions;

public static class ServiceCollection
{
	public static IUnityContainer AddServices(this IUnityContainer container)
	{
		container.RegisterType<EmployeController>();
		container.RegisterType<IEmployeeRepository, EmployeeRepository>();
		container.RegisterSingleton<ILocalStorage, LocalStorage>();

		return container;
	}
}
