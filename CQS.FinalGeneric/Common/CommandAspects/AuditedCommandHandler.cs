using CQS.DB.Models;
using CQS.FinalGeneric.Commands.Base;
using Newtonsoft.Json;
using System;

namespace CQS.FinalGeneric.Common.CommandAspects
{
    public class AuditedCommandHandler<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> commandHandler;

        public AuditedCommandHandler(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }
        public void Handle(TCommand command)
        {
            commandHandler.Handle(command);

            var entry = new Activity
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Operation = "CreateProduct",
                Data = JsonConvert.SerializeObject(command)
            };

            //Persist the Activity
        }
    }
}
