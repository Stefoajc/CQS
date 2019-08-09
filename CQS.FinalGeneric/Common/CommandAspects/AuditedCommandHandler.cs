using CQS.DB.Models;
using CQS.FinalGeneric.Commands.Base;
using Newtonsoft.Json;
using System;

namespace CQS.FinalGeneric.Common.CommandAspects
{
    public class AuditedCommandHandler<TResult> : ICommandHandler<TResult>
    {
        private readonly ICommandHandler<TResult> commandHandler;

        public AuditedCommandHandler(ICommandHandler<TResult> commandHandler)
        {
            this.commandHandler = commandHandler;
        }
        public void Handle(TResult command)
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
