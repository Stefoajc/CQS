using CQS.FinalGeneric.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.FinalGeneric.Mediator
{
    public interface IQueryProcessor
    {
        TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
