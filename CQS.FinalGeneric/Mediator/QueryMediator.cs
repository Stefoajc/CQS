using System;
using CQS.FinalGeneric.Queries.Base;
using SimpleInjector;

namespace CQS.FinalGeneric.Mediator
{
    public class QueryMediator : IQueryProcessor
    {
        private readonly Container container;

        public QueryMediator(Container container)
        {
            this.container = container;
        }

        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = container.GetInstance<IQueryHandler<TQuery, TResult>>();

            return handler.Handle(query);
        }
    }
}
