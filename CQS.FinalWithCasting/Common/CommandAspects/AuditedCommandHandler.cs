using CQS.DB.Models;
using CQS.FinalWithCasting.Commands.Base;
using Newtonsoft.Json;
using System;

namespace CQS.FinalWithCasting.Common.CommandAspects
{
    public class AuditedCommandHandler : ICommandHandler
    {
        private readonly ICommandHandler commandHandler;

        public AuditedCommandHandler(ICommandHandler commandHandler)
        {
            this.commandHandler = commandHandler;
        }
        public void Handle(object command)
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
