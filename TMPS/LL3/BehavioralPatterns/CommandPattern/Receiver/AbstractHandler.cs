using CommandPattern.Models;

namespace CommandPattern.Receiver;

public abstract class AbstractHandler<T> where T : class
{
    public AbstractHandler<T>? Successor { get; private set; }

    public AbstractHandler<T> SetSuccessor(AbstractHandler<T> successor)
    {
        this.Successor = successor;
        return successor;
    }

    public abstract void Handle(User user);
}
