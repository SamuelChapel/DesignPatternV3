namespace DesignPatternV3.Business.Contracts.Common;

public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
{
	Task<TResult> Handle(TCommand command);
}

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
	Task Handle(TCommand command);
}
