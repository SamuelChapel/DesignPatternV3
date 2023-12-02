using DesignPatternV3.Repository.Contracts;

namespace DesignPatternV3.Repository;

public class LocalStorage : ILocalStorage
{
	private LocalStorage(IEmployeeRepository employeeRepository)
	{
		EmployeeRepository = employeeRepository;
	}

	public IEmployeeRepository EmployeeRepository { get; }
}
