using CommandPattern.Models;
using CommandPattern.Receiver;
using CommandPattern.Repository;

namespace CommandPattern.CommandHandlers;

public class SaveUserCommandHandler
{
    private readonly AbstractHandler<User> userExists;
    private readonly AbstractHandler<User> userCreate;

    public SaveUserCommandHandler(IUserRepository userRepository)
    {
        this.userExists = new UserExistsHandler(userRepository);
        this.userCreate = new UserCreateHandler(userRepository);
    }

    public void SaveUserData(User user)
    {
        userExists.SetSuccessor(userCreate);
        userExists.Handle(user);
    }
}
