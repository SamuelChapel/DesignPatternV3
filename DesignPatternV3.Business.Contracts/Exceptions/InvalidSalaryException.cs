namespace DesignPatternV3.Business.Contracts.Exceptions;

public class InvalidSalaryException : Exception
{
	public override string Message => "Le salaire doit être supérieur à 0";
}
