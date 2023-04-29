using CommandPattern.Commands;
using CommandPattern.Models;
using CommandPattern.CommandHandlers;

namespace CommandPattern.ConcreteCommand;

public class SaveUserCommand : IUserCommand
{
    public readonly SaveUserCommandHandler saveUserCommandHandler;
    public readonly User user;

    public SaveUserCommand(User user, SaveUserCommandHandler saveUserCommandHandler)
    {
        this.saveUserCommandHandler = saveUserCommandHandler;
        this.user = user;
    }

    public void Execute()
    {
        saveUserCommandHandler.SaveUserData(this.user);
    }
}

