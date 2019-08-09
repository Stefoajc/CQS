namespace CQS.FinalWithCasting.Commands.Base
{
    public interface ICommandHandler
    {
        void Handle(object command);
    }
}
