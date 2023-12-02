namespace DesignPatternV3.Entities.Exceptions;

public class InvalidSalaryException : Exception
{
    public override string Message => "Le salaire doit être supérieur";
}
