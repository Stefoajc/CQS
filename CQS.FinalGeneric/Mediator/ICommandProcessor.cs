namespace CQS.FinalGeneric.Mediator
{
    interface ICommandProcessor
    {
        void Process<TCommand>(TCommand command);
    }
}
