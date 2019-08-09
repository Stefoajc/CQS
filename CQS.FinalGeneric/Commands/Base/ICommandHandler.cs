using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.FinalGeneric.Commands.Base
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
