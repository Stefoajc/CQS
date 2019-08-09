namespace CQS.FinalGeneric.Queries.Base
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
