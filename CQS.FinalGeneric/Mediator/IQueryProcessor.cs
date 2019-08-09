using CQS.FinalGeneric.Queries.Base;

namespace CQS.FinalGeneric.Mediator
{
    public interface IQueryProcessor
    {
        TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
