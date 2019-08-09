namespace CQS.FinalGeneric.Commands.Base
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
