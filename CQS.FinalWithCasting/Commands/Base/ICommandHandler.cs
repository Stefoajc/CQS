using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.FinalWithCasting.Commands.Base
{
    public interface ICommandHandler
    {
        void Handle(object command);
    }
}
