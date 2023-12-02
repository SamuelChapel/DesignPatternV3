namespace DesignPatternV3.Repository.Contracts;

public interface ILocalStorage
{
	IEmployeeRepository EmployeeRepository { get; }
}
