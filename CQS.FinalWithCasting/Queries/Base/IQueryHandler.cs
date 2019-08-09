namespace CQS.FinalWithCasting.Queries.Base
{
    public interface IQueryHandler
    {
        object Handle(object query);
    }
}
