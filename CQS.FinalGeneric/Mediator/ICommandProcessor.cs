using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.FinalGeneric.Mediator
{
    interface ICommandProcessor
    {
        void Process<TCommand>(TCommand command);
    }
}
