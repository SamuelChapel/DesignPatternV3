namespace DesignPatternV3.Business.Contracts.Exceptions.Employees;

public class EmployeeNotFoundException(int Id) : Exception
{
	public override string Message => $"L'employé avec l'id {Id} n'a pas été trouvé";
}
