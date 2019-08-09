using CQS.FinalGeneric.Commands.Base;
using SimpleInjector;

namespace CQS.FinalGeneric.Mediator
{
    public class CommandMediator : ICommandProcessor
    {
        private readonly Container container;

        public CommandMediator(Container container)
        {
            this.container = container;
        }

        public void Process<TCommand>(TCommand command)
        {
            var commandHandler = container.GetInstance<ICommandHandler<TCommand>>();
            commandHandler.Handle(command);
        }
    }
}
