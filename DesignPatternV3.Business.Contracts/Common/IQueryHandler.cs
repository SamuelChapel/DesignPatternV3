namespace DesignPatternV3.Business.Contracts.Common;

public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
{
	public Task<TResult> Handle(TQuery query);
}

public interface IQuerySearcherHandler<in TQuery, TResult, TCountResult> where TQuery : IQuery
{
	public Task<TResult> Search(TQuery query);

	public Task<TCountResult> Count(TQuery query);
}
